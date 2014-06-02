using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Library.Models;
using Library.Services;
using Library.Repositories;
using System.Data.Entity;
using Library.Helpers;

namespace Library
{
    public partial class LibraryForm : Form
    {

        ServiceFactory serviceFactory = new ServiceFactory();
        
        IService<Author> authorService;
        IService<BookCopy> bookCopyService;
        IService<Book> bookService;
        IService<Loan> loanService;
        IService<Member> memberService;
        SearchService searchService;

        //Algorithm class used to compare two strings, has a method iLD that takes 2 strings and returns the similarity as a number.
        //0 - 100 where 0 is perfect match and 100 is completetly different.
        LevenshteinAlgorithm levenAlgo = new LevenshteinAlgorithm();

        /// <summary>
        /// Enum for searchcombobox
        /// </summary>
        public enum searchComboEnum 
        {
            AllBooks, BookTitle, AuthorName, ISBN
        }

        /// <summary>
        /// enum for loansearchcombobox
        /// </summary>
        public enum loanSearchEnum
        {
            AllActiveLoans, ByMember, LoansOverdue, MemberLoansOverdue
        }

        /// <summary>
        /// enum for add/remove combobox
        /// </summary>
        public enum addRemoveEnum
        {
            AddBook, AddAuthor, AddBookCopy, RemoveBook, RemoveAuthor, RemoveBookCopy, AddMember
        }

        public LibraryForm()
        {
            InitializeComponent();

            // Uncomment the line you wish to use
            // Use a derived strategy with a Seed-method
            Database.SetInitializer<LibraryContext>(new LibraryDbInit());

            // Recreate the database only if the models change
            //Database.SetInitializer<LibraryContext>(new DropCreateDatabaseIfModelChanges<LibraryContext>());

            // Always drop and recreate the database
            //Database.SetInitializer<LibraryContext>(new DropCreateDatabaseAlways<LibraryContext>());

            //instatiate services
            authorService = serviceFactory.GetAuthorService();
            bookCopyService = serviceFactory.GetBookCopyService();
            bookService = serviceFactory.GetBookService();
            loanService = serviceFactory.GetLoanService();
            memberService = serviceFactory.GetMemberService();
            searchService = serviceFactory.GetSearchService();

            //set event subscriptions
            authorService.Updated += libraryService_Updated;
            bookCopyService.Updated += libraryService_Updated;
            bookService.Updated += libraryService_Updated;
            loanService.Updated += libraryService_Updated;
            memberService.Updated += libraryService_Updated;

            cmbxSearchBy.Items.Add(searchComboEnum.AllBooks);
            cmbxSearchBy.Items.Add(searchComboEnum.BookTitle);
            cmbxSearchBy.Items.Add(searchComboEnum.AuthorName);
            cmbxSearchBy.Items.Add(searchComboEnum.ISBN);
            cmbxSearchBy.SelectedIndex = 0;

            cmbxLoanDisplay.Items.Add(loanSearchEnum.AllActiveLoans);
            cmbxLoanDisplay.Items.Add(loanSearchEnum.ByMember);
            cmbxLoanDisplay.Items.Add(loanSearchEnum.LoansOverdue);
            cmbxLoanDisplay.Items.Add(loanSearchEnum.MemberLoansOverdue);
            cmbxLoanDisplay.SelectedIndex = 0;

            cbbxAction.Items.Add(addRemoveEnum.AddBook);
            cbbxAction.Items.Add(addRemoveEnum.AddAuthor);
            cbbxAction.Items.Add(addRemoveEnum.AddBookCopy);
            cbbxAction.Items.Add(addRemoveEnum.RemoveBook);
            cbbxAction.Items.Add(addRemoveEnum.RemoveAuthor);
            cbbxAction.Items.Add(addRemoveEnum.RemoveBookCopy);
            cbbxAction.Items.Add(addRemoveEnum.AddMember);
            cbbxAction.SelectedIndex = 0;

            searchListView.Columns.Add("Local Id", 50);
            searchListView.Columns.Add("ISBN", 90);
            searchListView.Columns.Add("Title",100);
            searchListView.Columns.Add("Author", 100);
            searchListView.Columns.Add("Copies",50);

            loanListView.Columns.Add("Local Id", 50);
            loanListView.Columns.Add("Title", 120);
            loanListView.Columns.Add("Due date", 90);
            loanListView.Columns.Add("Member SSNR", 90);

            mtxtbxSSNR1.Click += new EventHandler(maskedTextBox_Click);
            mtxtbxSSNRadd.Click += new EventHandler(maskedTextBox2_Click);
            mtxtbxSSNRloan.Click += new EventHandler(maskedTextBox1_Click);

            //Fill searchlistview with all books
            foreach (Book b in bookService.All())
            {
                ListViewItem item = new ListViewItem(new[] { Convert.ToString(b.Id), b.Isbn, b.Title, b.Author.Name, b.Copies.Where(c => c.IsLoaned == false).Count().ToString() });

                searchListView.Items.Add(item);
            }

        }

       
        /// <summary>
        /// Method that fires when Updated is called in any of the services implementing IService
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void libraryService_Updated(object sender, EventArgs e)
        {
            if (chbxInStock.Checked)
            {
                FillListViewSearchResultAvailableBooks();
            }
            else
            {
                FillListViewSearchResultAllBooks();
            }
            FillListViewLoans();
            Cleartxtboxes();
        }

        /// <summary>
        /// Filterbutton click event method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterButton_Click(object sender, EventArgs e)
        {
            if (chbxInStock.Checked)
            {
                FillListViewSearchResultAvailableBooks();
            }
            else
            {
                FillListViewSearchResultAllBooks();
            }
        }
        /// <summary>
        /// Method that fills the searchlistview with available books
        /// </summary>
        public void FillListViewSearchResultAvailableBooks()
        {
            searchListView.Items.Clear();
            
            switch ((searchComboEnum)cmbxSearchBy.SelectedItem)
            {
                case searchComboEnum.AllBooks:
                    foreach (Book b in bookService.All().Where(b => b.Copies.Where(c => c.IsLoaned == false).Count() != 0))
                    {
                        ListViewItem item = new ListViewItem(new [] {Convert.ToString(b.Id), b.Isbn, b.Title, b.Author.Name, b.Copies.Where(c=> c.IsLoaned == false).Count().ToString()});
                        
                        searchListView.Items.Add(item);
                    }
                    break;
                case searchComboEnum.AuthorName:
                    foreach (Book b in bookService.All().Where(book => levenAlgo.iLD(book.Author.Name, txtbxSearchInput.Text) < 60).Where(b => b.Copies.Where(c => c.IsLoaned == false).Count() != 0))
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(b.Id), b.Isbn, b.Title, b.Author.Name, b.Copies.Where(c => c.IsLoaned == false).Count().ToString() });
                        item.Tag = b;
                        searchListView.Items.Add(item);
                    }
                    break;
                case searchComboEnum.BookTitle:
                    foreach (Book b in bookService.All().Where(book => levenAlgo.iLD(book.Title, txtbxSearchInput.Text) < 60).Where(b => b.Copies.Where(c => c.IsLoaned == false).Count() != 0))
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(b.Id), b.Isbn, b.Title, b.Author.Name, b.Copies.Where(c => c.IsLoaned == false).Count().ToString() });
                        item.Tag = b;
                        searchListView.Items.Add(item);
                    }
                    break;
                case searchComboEnum.ISBN:
                    foreach (Book b in bookService.All().Where(book => levenAlgo.iLD(book.Isbn, txtbxSearchInput.Text) < 60).Where(b => b.Copies.Where(c => c.IsLoaned == false).Count() != 0))
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(b.Id), b.Isbn, b.Title, b.Author.Name, b.Copies.Where(c => c.IsLoaned == false).Count().ToString() });
                        searchListView.Items.Add(item);
                    }
                    break;
                default:
                    break;
                    
            }
        }

        /// <summary>
        /// Method that fills the searchlistview with all books
        /// </summary>
        public void FillListViewSearchResultAllBooks()
        {
            searchListView.Items.Clear();

            switch ((searchComboEnum)cmbxSearchBy.SelectedItem)
            {
                case searchComboEnum.AllBooks:
                    foreach (Book b in bookService.All())
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(b.Id), b.Isbn, b.Title, b.Author.Name, b.Copies.Where(c => c.IsLoaned == false).Count().ToString() });

                        searchListView.Items.Add(item);
                    }
                    break;
                case searchComboEnum.AuthorName:
                    foreach (Book b in bookService.All().Where(book => levenAlgo.iLD(book.Author.Name, txtbxSearchInput.Text) < 60))
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(b.Id), b.Isbn, b.Title, b.Author.Name, b.Copies.Where(c => c.IsLoaned == false).Count().ToString() });
                        item.Tag = b;
                        searchListView.Items.Add(item);
                    }
                    break;
                case searchComboEnum.BookTitle:
                    foreach (Book b in bookService.All().Where(book => levenAlgo.iLD(book.Title, txtbxSearchInput.Text) < 60 ))
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(b.Id), b.Isbn, b.Title, b.Author.Name, b.Copies.Where(c => c.IsLoaned == false).Count().ToString() });
                        item.Tag = b;
                        searchListView.Items.Add(item);
                    }
                    break;
                case searchComboEnum.ISBN:
                    foreach (Book b in bookService.All().Where(book => levenAlgo.iLD(book.Isbn, txtbxSearchInput.Text) < 60))
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(b.Id), b.Isbn, b.Title, b.Author.Name, b.Copies.Where(c => c.IsLoaned == false).Count().ToString() });
                        searchListView.Items.Add(item);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Method that fills the loan listview
        /// </summary>
        public void FillListViewLoans()
        {
            loanListView.Items.Clear();

            switch ((loanSearchEnum)cmbxLoanDisplay.SelectedItem)
            {
                case loanSearchEnum.ByMember:
                    try { iscorrectofrmat(mtxtbxSSNRloan); }
                    catch (InvalidSSNRException) { MessageBox.Show(mtxtbxSSNRloan.Text + " is not a valid Social security number, please enter a social scurity number by the form YYMMDD-XXXX"); }
                    try
                    { if (memberService.Find(Convert.ToInt16(mtxtbxSSNRloan.Text)) == null) { throw new NoMemberFoundException(); } }
                    catch (NoMemberFoundException)
                    { MessageBox.Show("Member not found"); }

                    foreach (Loan loan in searchService.CheckMemberActiveLoans(mtxtbxSSNRloan.Text))
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(loan.Id), loan.BookCopy.Book.Title, loan.ToReturn.ToShortDateString(), loan.Member.SocialSecurityNr });
                        loanListView.Items.Add(item);
                    }

                    break;
                case loanSearchEnum.AllActiveLoans:
                    foreach (Loan loan in searchService.CheckActiveLoans())
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(loan.Id), loan.BookCopy.Book.Title, loan.ToReturn.ToShortDateString(), loan.Member.SocialSecurityNr });
                        loanListView.Items.Add(item);
                    }
                    break;
                case loanSearchEnum.LoansOverdue:
                    foreach (Loan loan in searchService.CheckLoansOverdue())
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(loan.Id), loan.BookCopy.Book.Title, loan.ToReturn.ToShortDateString(), loan.Member.SocialSecurityNr });
                        loanListView.Items.Add(item);
                    }
                    break;
                case loanSearchEnum.MemberLoansOverdue:
                    try { iscorrectofrmat(mtxtbxSSNRloan); }
                    catch (InvalidSSNRException) { MessageBox.Show(mtxtbxSSNRloan.Text + " is not a valid Social security number, please enter a social scurity number by the form YYMMDD-XXXX"); }
                    try
                    { if (memberService.Find(Convert.ToInt16(mtxtbxSSNRloan.Text)) == null) { throw new NoMemberFoundException(); } }
                    catch (NoMemberFoundException)
                    { MessageBox.Show("Member not found"); }
                    foreach (Loan loan in searchService.CheckMemberLoansOverdue(mtxtbxSSNRloan.Text))
                    {
                        ListViewItem item = new ListViewItem(new[] { Convert.ToString(loan.Id), loan.BookCopy.Book.Title, loan.ToReturn.ToShortDateString(), loan.Member.SocialSecurityNr });
                        loanListView.Items.Add(item);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Clear button click method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            searchListView.Items.Clear();
            txtbxDescription.Text = String.Empty;
        }

        /// <summary>
        /// Event method for the loan submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loanSelectedButton_Click(object sender, EventArgs e)
        {
            try
            {
                iscorrectofrmat(mtxtbxSSNR1);
                string memberSocialSecNr = mtxtbxSSNR1.Text;
                int bookId = Convert.ToInt16(searchListView.SelectedItems[0].SubItems[0].Text);
                Member theMember;
                BookCopy theCopy;

                //fetch bookcopy and member from repos and catch exceptions to throw specific exceptions
                try
                {
                    var bookCopy = bookCopyService.All().Where(b => b.Book.Id == bookId && b.IsLoaned == false).First();
                    theCopy = bookCopy;
                }
                catch (InvalidOperationException)
                {
                    throw new NoCopyAvailableException();
                }
                try
                {
                    var member = memberService.All().Where(m => m.SocialSecurityNr == memberSocialSecNr).First();
                    theMember = member;
                }
                catch (InvalidOperationException)
                {
                    throw new NoMemberFoundException();
                }

                //create a new loan
                Loan newLoan = new Loan { BookCopy = theCopy, Member = theMember, TimeofLoan = DateTime.Today.Date, ToReturn = DateTime.Today.AddDays(15).Date, Returned = null };
                //Add the loan to the repo
                loanService.Add(newLoan);
                theCopy.IsLoaned = true;
                bookCopyService.Edit(theCopy);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Select a book to loan");
            }
            catch (NoMemberFoundException)
            {
                MessageBox.Show("Member not found");
            }
            catch (NoCopyAvailableException)
            {
                MessageBox.Show(searchListView.SelectedItems[0].SubItems[2].Text + " is not available at this moment.");

            }
            catch (InvalidSSNRException)
            {
                MessageBox.Show(mtxtbxSSNR1.Text + " is not a valid Social security number, please enter a social scurity number by the form YYMMDD-XXXX");
            }
        }

        /// <summary>
        /// Event method for the display loans button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void displayLoansButton_Click(object sender, EventArgs e)
        {
            FillListViewLoans();
        }

        /// <summary>
        /// Event method for return loan button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void returnLoanButton_Click(object sender, EventArgs e)
        {
                //fetch loanid from listview
                int loanId = Convert.ToInt16(loanListView.SelectedItems[0].SubItems[0].Text);

                //fetch loan from loanrepo with loanid
                var loanToReturn = loanService.All().Where(loa => loa.Id == loanId).First();
                
                //check if loan is overdue
                if (loanToReturn.ToReturn < DateTime.Today)
                {
                    //calculate the fine
                    int fine = 10 * (DateTime.Today - loanToReturn.ToReturn).Days;

                    //display fine and possibility to cancel the loan return
                    DialogResult dr = MessageBox.Show("The book is overdue, the fine is " + fine + "kr", "ATTENTION!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    switch (dr)
                    {
                        case DialogResult.OK:
                            loanService.Remove(loanToReturn);
                            break;
                        case DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    loanService.Remove(loanToReturn);
                }
            
        }

        /// <summary>
        /// Method that fires when cbbxAction selected index changes. Displays/Hides elements and sets lable texts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbxAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbxAction.SelectedIndex)
            { 
                case 0:
                    txtbxInput2.Visible = true;
                    label5.Text = "Booktitle:";
                    label6.Visible = true;
                    label6.Text = "Authorname:";
                    txtbxInput3.Visible = true;
                    txtbxInput4.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                    label8.Text = "Description";
                    label7.Text = "ISBN";
                    mtxtbxSSNRadd.Visible = false;
                    break;
                case 1:
                    txtbxInput1.Visible = true;
                    txtbxInput2.Visible = false;
                    label6.Visible = false;
                    label5.Text = "Authorname:";
                    txtbxInput3.Visible = false;
                    txtbxInput4.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    mtxtbxSSNRadd.Visible = false;
                    break;
                case 2:
                    txtbxInput2.Visible = false;
                    label6.Visible = false;
                    label5.Text = "Booktitle:";
                    txtbxInput3.Visible = false;
                    txtbxInput4.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    mtxtbxSSNRadd.Visible = false;
                    break;
                case 3:
                    txtbxInput2.Visible = false;
                    label6.Visible = false;
                    label5.Text = "Booktitle:";
                    txtbxInput3.Visible = false;
                    txtbxInput4.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    mtxtbxSSNRadd.Visible = false;
                    break;
                case 4:
                    txtbxInput2.Visible = false;
                    label6.Visible = false;
                    label5.Text = "Authorname:";
                    txtbxInput3.Visible = false;
                    txtbxInput4.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    mtxtbxSSNRadd.Visible = false;
                    break;
                case 5:
                    txtbxInput2.Visible = false;
                    label6.Visible = false;
                    label5.Text = "Copy Id:";
                    txtbxInput3.Visible = false;
                    txtbxInput4.Visible = false;
                    label7.Visible = false;
                    label8.Visible = false;
                    mtxtbxSSNRadd.Visible = false;
                    break;
                case 6:
                    txtbxInput1.Visible = true;
                    txtbxInput2.Visible = false;
                    mtxtbxSSNRadd.Visible = true;
                    label5.Text = "Name:";
                    label6.Text = "SSNR:";
                    txtbxInput3.Visible = false;
                    txtbxInput4.Visible = false;
                    label6.Visible = true;
                    label7.Visible = false;
                    label8.Visible = false;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Event method for the submitbutton in the add/remove section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            

            switch ((addRemoveEnum)cbbxAction.SelectedIndex)
            {
                case addRemoveEnum.AddBook://add book
                    {
                        //txtbxInput1 = title
                        //txtbxInput2 = authorname
                        //txtbxInput3 = ISBN
                        //txtbxInput4 = description
                        Author theAuthor;
                        Book theBook;
                        try
                        {
                            if (txtbxInput1.Text.Length == 0 || txtbxInput2.Text.Length == 0 || txtbxInput3.Text.Length == 0 || txtbxInput4.Text.Length == 0)
                            {
                                throw new InvalidInputException();
                            }

                            if (authorService.All().Where(a => a.Name == txtbxInput2.Text).Count() == 0)
                            {
                                theAuthor = new Author { Name = txtbxInput2.Text, Books = new List<Book>() };
                                authorService.Add(theAuthor);
                            }
                            else
                            {
                                theAuthor = authorService.All().Where(A => A.Name == txtbxInput2.Text).First();
                            }

                            theBook = new Book { Title = txtbxInput1.Text, Author = theAuthor, Copies = new List<BookCopy>(), Description = txtbxInput4.Text, Isbn = txtbxInput3.Text };
                            bookService.Add(theBook);
                        }

                        catch (InvalidInputException) { MessageBox.Show("Some input was invalid, please controll that none of the input textboxes are empty"); }
                        break;
                    }

                case addRemoveEnum.AddAuthor: //Add Author
                    {
                        Author theAuthor;

                        //txtbxInput1 = authorname
                        try
                        {
                            if (txtbxInput1.Text.Length == 0)
                            {
                                throw new InvalidInputException();
                            }
                            theAuthor = new Author { Name = txtbxInput1.Text, Books = new List<Book>() };
                            authorService.Add(theAuthor);
                        }
                        catch (InvalidInputException)
                        {
                            MessageBox.Show("An author needs to have a name, please input a name in the name textbok");
                            txtbxInput1.Select();
                        }
                        break;
                    }
                case addRemoveEnum.AddBookCopy: //Add book copy
                    {
                        //txtbxInput1 = bookname
                        BookCopy theBookCopy;
                        Book theBook;

                        try
                        {
                            if (txtbxInput1.Text.Length == 0)
                            {
                                throw new InvalidInputException();
                            }

                            theBook = bookService.All().Where(B => B.Title == txtbxInput1.Text).First();
                            theBookCopy = new BookCopy { Book = theBook, IsLoaned = false, Condition = "New" };

                            bookCopyService.Add(theBookCopy);
                            theBook.Copies.Add(theBookCopy);
                        }
                        catch (InvalidInputException)
                        {
                            MessageBox.Show("Please specify wich book you would like to add a copy of in the booktitle textbox");
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("The book was not found, please make sure that the book exists before creating a copy of it");
                        }
                        break;
                    }
                case addRemoveEnum.RemoveBook: //RemoveBook
                    {
                        //txtbxInput1 = bookname
                        Book theBook;
                        try
                        {
                            if (txtbxInput1.Text.Length == 0)
                            {
                                throw new InvalidInputException();
                            }

                            theBook = bookService.All().Where(B => B.Title == txtbxInput1.Text).First();

                            foreach (var copy in bookCopyService.All().Where(b => b.Book == theBook))
                            {
                                //remove every copy of the book from bookcopyrepo
                                bookCopyService.Remove(copy);
                            }

                            //Remove the book from bookrepo
                            bookService.Remove(theBook);
                        }
                        catch (InvalidInputException)
                        {
                            MessageBox.Show("Please specify wich book yo would like to remove in the booktitle textbox");
                            txtbxInput1.Select();
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("The book was not found, please controll that the book exists and that you've entered the correct title");
                            txtbxInput1.Select();
                        }
                        break;
                    }
                case addRemoveEnum.RemoveAuthor: //Remove author
                    {
                        //txtbxInput1 = authorname
                        Author theAuthor;
                        try
                        {
                            if (txtbxInput1.Text.Length == 0)
                            {
                                throw new InvalidInputException();
                            }
                            //feth author
                            theAuthor = authorService.All().Where(a => a.Name == txtbxInput1.Text).First();

                            //remove all bookcopies of books written by the author
                            foreach(BookCopy bc in bookCopyService.All().Where(b => b.Book.Author == theAuthor))
                            {
                                bookCopyService.Remove(bc);
                            }

                            //remove all books written by the author
                            foreach (Book b in bookService.All().Where(b => b.Author == theAuthor))
                            {
                                bookService.Remove(b);
                            }

                            //finally remove the author
                            authorService.Remove(theAuthor);
                        }
                        catch (NotImplementedException)
                        {
                            MessageBox.Show("Not yet implemented, not a requirement for the project");
                        }
                        
                        catch (InvalidInputException)
                        {
                            MessageBox.Show("Please input a Author Name in the author name input box");
                            txtbxInput1.Select();
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("The Author was not found, please make sure that the author exists and you've entered the correct name");
                            txtbxInput1.Select();

                        }
                        break;
                    }
                case addRemoveEnum.RemoveBookCopy: //remove book copy
                    {
                        //txtbxInput1 = bookcopyid

                        BookCopy theBookCopy;
                        int bookCopyId = Convert.ToInt16(txtbxInput1.Text);
                        try
                        {
                            if (txtbxInput1.Text.Length == 0)
                            {
                                throw new InvalidInputException();
                            }
                            theBookCopy = bookCopyService.All().Where(bc => bc.Id == bookCopyId).First();

                            bookCopyService.Remove(theBookCopy);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Please make sure that the input in the ID textbox is only numbers");
                            txtbxInput1.Select();
                        }
                        catch (InvalidOperationException)
                        {
                            MessageBox.Show("The copy was not found, please make sure that you've entered the right ID and that the copy exists");
                        }
                        break;
                    }
                case addRemoveEnum.AddMember: //add member
                    {
                        //txtbxInput1 = name
                        //mtxtbxSSNRadd = socialssnr
                        Member newMember;

                        try { iscorrectofrmat(mtxtbxSSNRadd); }
                        catch (InvalidSSNRException) { MessageBox.Show(mtxtbxSSNRadd.Text + " is not a valid Social security number, please enter a social scurity number by the form YYMMDD-XXXX"); }
                        try
                        {
                            if (txtbxInput1.Text.Length == 0)
                            {
                                throw new InvalidInputException();
                            }

                            //create new member
                            newMember = new Member { SocialSecurityNr = mtxtbxSSNRadd.Text, Name = txtbxInput1.Text };
                            memberService.Add(newMember);
                        }
                        catch (InvalidInputException)
                        {
                            MessageBox.Show("A member can't be created without a full name, please enter [name1 name2] in the name textbox");
                            txtbxInput1.Focus();
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        
        /// <summary>
        /// Method that fires when cmbxSearchBy selected index changes. Displays/Hides elements and sets lable texts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbxSearchBy.SelectedIndex)
            {
                case 0:
                    label2.Visible = false;
                    txtbxSearchInput.Visible = false;
                    break;
                default:
                    label2.Visible = true;
                    txtbxSearchInput.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Method that masked check textboxes is of the same format
        /// </summary>
        /// <param name="mtbx"></param>
        private void iscorrectofrmat(MaskedTextBox mtbx)
        {
            if (!mtbx.MaskCompleted)
            {
                throw new InvalidSSNRException();
            }

        }

        /// <summary>
        /// Event method for maskedtextbox2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maskedTextBox2_Click(object sender, EventArgs e)
        {
            this.mtxtbxSSNRadd.Select(0, 0);
        }
        
        /// <summary>
        /// Event method for maskedtextbox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maskedTextBox1_Click(object sender, EventArgs e)
        {
            this.mtxtbxSSNRloan.Select(0, 0);
        }

        /// <summary>
        /// Event method for maskedtextbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maskedTextBox_Click(object sender, EventArgs e)
        {
            this.mtxtbxSSNR1.Select(0, 0);
        }

        /// <summary>
        /// Method that fires on cmbxloandisplay indexchanged. Hides and changes form elements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxLoanDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbxLoanDisplay.SelectedIndex)
            {
                case 1:
                    mtxtbxSSNRloan.Visible = true;
                    label9.Visible = true;
                    break;
                case 3:
                    mtxtbxSSNRloan.Visible = true;
                    label9.Visible = true;
                    break;
                default:
                    mtxtbxSSNRloan.Visible = false;
                    label9.Visible = false;
                    break;
            }
           
        }
        
        /// <summary>
        /// Method to clear textboxes
        /// </summary>
        private void Cleartxtboxes()
        {
            txtbxInput1.Clear();
            txtbxInput2.Clear();
            txtbxSearchInput.Clear();
            txtbxInput3.Clear();
            txtbxInput4.Clear();
            mtxtbxSSNR1.Clear();
            mtxtbxSSNRloan.Clear();
            mtxtbxSSNRadd.Clear();
        }

        /// <summary>
        /// method that displays the book description in txtbxdescription
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descriptionButton_Click(object sender, EventArgs e)
        {
            int bookid = Convert.ToInt16(searchListView.SelectedItems[0].SubItems[0].Text);

            Book b = bookService.Find(bookid);

            txtbxDescription.Text = b.Description;
        }
        
    }
}
