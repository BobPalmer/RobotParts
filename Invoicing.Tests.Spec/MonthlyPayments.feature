Feature: Monthly Payments
	In order to see my projected monthly paynment
	As a customer
	I want to be able to calculate my loan terms

Scenario: Standard rate and terms 
	Given I have entered an APR of 7.5%
	And a financed amount of $10,000.00
	And terms of 24 months
	When I request a payment schedule
	Then the monthly payment should be $450.00
	And the final payment should be $449.90

Scenario:  Preferred Rate and long term loan
	Given I have entered an APR of 4%
	And a financed amount of $125,000
	And terms of 15 years
	When I request a payment schedule
	Then the monthly payment should be $924.61
	And the final payment should be $924.59

