using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BANK
{
    public delegate void ChangeInTheAccount(object source,EventArgs e);
    
    class Account
    {

        public string Owner { get; set; }
        public int Balance { get; set; }
        public event ChangeInTheAccount WithdrwEvent;
        public event ChangeInTheAccount DepositEvent;
        public event ChangeInTheAccount ChangeOwnerEvent;
        public event ChangeInTheAccount OverdraftAccountEvent;
        public Account(string owner,int balance)
        {
            this.Owner = owner;
            this.Balance = balance;
        }
        public Account()
        {
            
        }
        public void ChangeOwner(string newOwner)
        {
            if(this.Owner!=newOwner)
            {
                this.Owner = newOwner;
                ChangeOwnerEvent?.Invoke(newOwner, new EventArgs());
            }
        }
        public void Transaction(int amount)
        {
          
            if (amount < 0)
            {
                if (this.Balance + amount >= 0)
                {
                   this.Balance =this.Balance += amount;
                    WithdrwEvent?.Invoke(amount, new EventArgs());
                }
                else if(this.Balance + amount<0)
                {
                    OverdraftAccountEvent?.Invoke(this, new EventArgs());
                }
            }
            if(amount > 0)
            {
                this.Balance = this.Balance + amount;
                DepositEvent?.Invoke(amount, new EventArgs());
            }
        }
      



    }
}
