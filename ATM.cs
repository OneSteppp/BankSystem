using System;
using System.Collections;

public class ATM {
	
	Bank bank;
	public ATM( Bank bank)
	{
		this.bank = bank;
	}
	
	public void DepositTransaction()
	{
        Show("please insert your deposit card");
        string id = GetInput();

        Show("please enter your password");
        string pwd = GetInput();

        Account account = bank.FindAccount(id, pwd);

        if (account == null)
        {
            Show("card invalid or password not corrent");
            return;
        }
        bool next = false;
        do
        {
            Show("1: display; 2: save; 3: withdraw");
            string op = GetInput();
            if (op == "1")
            {
                Show("balance: " + account.money);
            }
            else if (op == "2")
            {
                Show("save money");
                string smoney = GetInput();
                double money = double.Parse(smoney);

                bool ok = account.SaveMoney(money);
                if (ok) Show("ok");
                else Show("eeer");

                Show("balance: " + account.money);
            }
            else if (op == "3")
            {
                Show("withdraw money");
                string smoney = GetInput();
                double money = double.Parse(smoney);

                bool ok = account.WithdrawMoney(money);
                if (ok) Show("ok");
                else Show("error");

                Show("balance: " + account.money);
            }
            Show("1:finish; 2:continue");
            op = GetInput();
            if (op == "1")
            {
                next = false;
            }
            else if (op == "2")
            {
                next = true;
            }
        }while (next);
		
	}
    public void CreditTransaction()
    {
        Show("please insert your credit card");
        string id = GetInput();

        Show("please enter your password");
        string pwd = GetInput();

        CreditCardAccount account = bank.FindCreditAccount(id, pwd);

        if (account == null)
        {
            Show("card invalid or password not corrent");
            return;
        }
        bool next = false;
        do
        {
            Show("1: display; 2: save; 3: withdraw");
            string op = GetInput();
            if (op == "1")
            {
                Show("limit: " + account.CreditLimit);
            }
            else if (op == "2")
            {
                Show("save money");
                string smoney = GetInput();
                double money = double.Parse(smoney);

                bool ok = account.SaveMoney(money);
                if (ok) Show("ok");
                else Show("eeer");

                Show("limit: " + account.CreditLimit);
            }
            else if (op == "3")
            {
                Show("withdraw money");
                string smoney = GetInput();
                double money = double.Parse(smoney);

                bool ok = account.WithdrawMoney(money);
                if (ok) Show("ok");
                else Show("error");

                Show("limit: " + account.CreditLimit);
            }
            Show("1:finish; 2:continue");
            op = GetInput();
            if (op == "1")
            {
                next = false;
            }
            else if (op == "2")
            {
                next = true;
            }
        } while (next);
        
    }


    public void Show(string msg)
	{
		Console.WriteLine(msg);
	}
	public string GetInput()
	{
		return Console.ReadLine();// ÊäÈë×Ö·û
	}
}
