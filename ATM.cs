using System;
using System.Collections;


public class BigMoneyFetchedEventArgs //参数类
{
    public string ID { set { _id = value; } get { return _id; } }
    private string _id;
    public double BigMoney { set { _bigMoney = value; } get { return _bigMoney; } }
    private double _bigMoney;

    public BigMoneyFetchedEventArgs(string id,double b) { this._id = id; this._bigMoney = b; }
}
//声明委托  大量取款
public delegate void BigMoneyFetchedEventHandler(object sender, BigMoneyFetchedEventArgs e);
public class ATM {
	
	Bank bank;
    public event BigMoneyFetchedEventHandler BigMoneyFetched;//声明事件，
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
                if(BigMoneyFetched != null)
                {
                    if (money > 10000)
                    {
                        BigMoneyFetched(this, new BigMoneyFetchedEventArgs(id, money));
                    }
                }
                bool ok = false;
                try
                {
                    ok = account.WithdrawMoney(money);
                }
                catch(Exception e)
                {
                    Console.WriteLine("出现了异常： {0}", e.Message);
                }
                finally
                {
                    if (ok) Show("ok");
                    else Show("error");

                    Show("balance: " + account.money);
                }
                

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
                if (BigMoneyFetched != null)
                {
                    if (money > 10000)
                    {
                        BigMoneyFetched(this, new BigMoneyFetchedEventArgs(id, money));
                    }
                }

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

                bool ok = false;
                try
                {
                    ok = account.WithdrawMoney(money);
                }
                catch(Exception e)
                {
                    Console.WriteLine("出现异常：{0}", e.Message);
                }
                finally
                {
                    if (ok) Show("ok");
                    else Show("error");

                    Show("limit: " + account.CreditLimit);
                }


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
		return Console.ReadLine();// 输入字符
	}
}
