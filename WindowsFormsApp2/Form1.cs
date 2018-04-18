using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data.SqlClient;



namespace WindowsFormsApp2
{
    public partial class Form1 : Form    {
       
         static IWebDriver Browser;


        public Form1()
        {
            InitializeComponent();
          //Browser.Manage().Window.Maximize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите элемент из списка");
            }
            else
            {
                
            }
        }

      
        public static bool IsElementExists(By iClassName)
        {
        
            try
            { 
                Browser.FindElement(iClassName);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            // Закрытие selenium
             Browser.Quit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Выберите элемент из списка");
            }
            else
            {
                Browser = new OpenQA.Selenium.Chrome.ChromeDriver();
                Browser.Manage().Window.Maximize();

                Browser.Navigate().GoToUrl(textBox1.Text);            
                             
                Thread.Sleep(1000);

                string notePoisk = "1)Нет окна поля для ввода";
                try
                {
                    IWebElement LohinInput = Browser.FindElement(By.Name("username"));
                    IWebElement PasswordInput = Browser.FindElement(By.Name("password"));

                    LohinInput.SendKeys("admin");
                    PasswordInput.SendKeys("123" + OpenQA.Selenium.Keys.Enter);
                    // проверка на наличие элемента
                    Thread.Sleep(5000);
                    if (IsElementExists(By.Id("notices")) == true)
                    {
                        IWebElement PasswordInput1 = Browser.FindElement(By.Id("password"));
                        PasswordInput1.SendKeys("admin" + OpenQA.Selenium.Keys.Enter);
                    }

                }
                catch (Exception ex)
                {
                    richTextBox2.Text = notePoisk.ToString() + "\n" + ex.Message;
                }                
            }
        }

        
        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(textBox1.Text);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                          
            }
            else
            {
                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }               
            }

        }
       
    }
}
