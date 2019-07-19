//Longjie Du
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JoesPet
{
    class VM : INotifyPropertyChanged
    {
        const decimal CRICKET = 24.75m;
        const decimal WORM = 44.99m;
        const decimal MICE = 19.99m;
        const decimal TAX_PCT = 15m;
        const decimal DELIVERY = 15m;
        const decimal LIMIT = 75m;
        private bool isDelivery=false;
        public bool IsDelivery { get { return isDelivery; } set { isDelivery = value; calcStandard();  onChange(); } }


        private decimal cricket;
        public decimal Cricket
        {
            get { return cricket; }
            set { cricket = value; calcStandard(); onChange(); }
        }
        private decimal worm;
        public decimal Worm
        {
            get { return worm; }
            set { worm = value; calcStandard(); onChange(); }
        }
        private decimal mice ;
        public decimal Mice
        {
            get { return mice; }
            set { mice = value;  calcStandard(); onChange(); }
        }
        private decimal standardCost;
        public decimal StandardCost
        {
            get { return standardCost; }
            set { standardCost = value; onChange(); }
        }
        private decimal tax;
        public decimal Tax
        {
            get { return tax; }
            set { tax = value; Tax=StandardCost*TAX_PCT; onChange(); }
        }
        private decimal deliveryCost;
        public decimal DeliveryCost
        {
            get { return deliveryCost; }
            set { deliveryCost = value;  onChange(); }
        }
        private decimal total;
        public decimal Total
        {
            get { return total; }
            set { total = value;  onChange(); }
        }
        public void calcDelivery()
        {
            if (IsDelivery == false) { DeliveryCost = 0; }
            else if (StandardCost < LIMIT) { DeliveryCost = 0; }
            else { DeliveryCost = DELIVERY; }
        }

        //public void calcCricket()
        //{
        //    Cricket =  cricket * CRICKET;
        //}
        //public void calcWorm()
        //{
        //    Worm = worm * WORM ;
        //}
        //public void calcMice()
        //{
        //    Mice = MICE * mice;
        //}
        public void calcStandard()
        {
            StandardCost = Cricket * CRICKET +Worm * WORM +Mice *MICE;
            calcDelivery();
        }
        public void calcTotal()
        {
            Total = StandardCost + DeliveryCost + Tax;
        }
        public void Save()
        {
            try
            {
                string FileData = getData();
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    File.AppendAllText(saveFileDialog.FileName, FileData + "\r\n");
                }
            }
            catch (Exception)
            { }
        }
        private string getData()
        {
            string data = "";
            data = "Joe's Pet Bill\r\n\r\n";
            data += "Crickets  " + Cricket + "\r\n";
            data += "Worm " + Worm + "\r\n";
            data += "Mice       " + Mice + "\r\n";
            data += "Deliver Cost      " + DeliveryCost + "\r\n";
            data += "Tax " + Tax + "\r\n";
            data += "Total Charges      " + Total + "\r\n";
            return data;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void onChange([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
