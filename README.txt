***************
*    SETUP    *
***************
1.  Create a new SQL Database (the examples uses InvoiceDemo, but any name works)
2.  Run Setup.SQL on your newly created SQL database.  This creates the schema and table data.
3.  Update Web.Config to reflect your connection string (Default is SQLExpress)
4.  Run the Unit Tests
5.  Enjoy!

Invoice Demo

Requirements:
-	User can add multiple items.  Items have:
		Name
		Unit Price
		Upfront Percentage
		Discount percent (editable)
		Quantity (editable)

-	An order has data as well:
		- Existing Credit
		- Gift Certificate Amount
		- Interest Rate
		- Number of payments

-	Calculate Payment Schedule will take the current order 
	from the screen and return the proposed schedule for payments:
		- Any remaining payment due at signing
		- Monthly payment amount
		- Final payment amount
		- Total Cost 

-	Additional rules:
		- Gift Certificates and credits are treated as cash
		- Gift Certificates are applied before credits
		- Discounts are expressed in a percentage off of the original cost
		- Discounts are applied at the line level
		- Minimum down payments are calculated after discounts

*******************
Demo Change
- Gift certs cannot be used for the down payment
  (all tests have commented out code that reflects the new spec)
