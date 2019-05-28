using System;
using System.Collections;
using System.Collections.Generic;

public class Bank {
	List<Account> accounts = new List<Account>();
    List<CreditCardAccount> credits = new List<CreditCardAccount>();
	
	public Account OpenAccount(string name,string id, string pwd, double money)
	{
		Account account = new Account(name,id, pwd, money);
		accounts.Add( account );		
		return account;
	}
    public CreditCardAccount OpenCreditAccount(string name, string id, string pwd, double money,double limit)
    {
        CreditCardAccount credit = new CreditCardAccount(name, id, pwd, money, limit);
        credits.Add(credit);
        return credit;
    }
	
	public bool CloseAccount( Account account) 
	{
		int idx = accounts.IndexOf(account);
		if( idx<0 )return false;
		accounts.Remove(account);
		return true;		
	}
    public bool CloseAccount(CreditCardAccount account)
    {
        int idx = credits.IndexOf(account);
        if (idx < 0) return false;
        credits.Remove(account);
        return true;
    }

    public Account FindAccount(string id, string pwd)
	{
		foreach(Account account in accounts)
		{
			if( account.IsMatch(id, pwd))
			{
				return account;
			}
		}
		return null;
	}
    public CreditCardAccount FindCreditAccount(string id, string pwd)
    {
        foreach (CreditCardAccount credit in credits)
        {
            if (credit.IsMatch(id, pwd))
            {
                return credit;
            }
        }
        return null;
    }


}
