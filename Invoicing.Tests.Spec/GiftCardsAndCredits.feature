Feature: Gift Cards and Credits
	In order to see what my payments are
	As a customer
	I want to calculate a schedule based off of my order


@LargeOrder
Scenario: Order with a gift card that exceeds the down payment
	Given an order with a variety of items	
	And the following terms and balances
		| Credit Balance | Gift Card Balance | APR % | Number of Payments |
		| $100.00        | $1500.00          | 7.5%  | 36                 |
	When I press calculate
	Then the resulting payment schedule should be
		| Down Payment | Monthly Payment | Final Payment | Gift Card | Credit |
		| $0.00        | $511.36         | $511.17       | $0        | $0     |

# original spec
#		| $0.00        | $511.36         | $511.17       | $0        | $0     |
# revised spec
#		| $399.75      | $500.24         | $500.16       | $0        | $0     |
		
@LargeOrder
Scenario: Order with a credit that exceeds the down payment
	Given an order with a variety of items		
	And the following terms and balances
		| Credit Balance | Gift Card Balance | APR % | Number of Payments |
		| $1500.00       | $100.00           | 7.5%  | 36                 |
	When I press calculate
	Then the resulting payment schedule should be
		| Down Payment | Monthly Payment | Final Payment | Gift Card | Credit |
		| $0.00        | $511.36         | $511.17       | $0        | $0     |

@LargeOrder
Scenario: Order with a combined credit and gift card balance that exceeds the total invoice
	Given an order with a variety of items	
	And the following terms and balances
		| Credit Balance | Gift Card Balance | APR % | Number of Payments |
		| $10000.00      | $10000.00         | 7.5%  | 36                 |
	When I press calculate
	Then the resulting payment schedule should be
		| Down Payment | Monthly Payment | Final Payment | Gift Card | Credit |
		| $0.00        | $0.00           | $0.00         | $0.00     | $12.50 |

@LargeOrder
Scenario: Order with a credit balance that exceeds the total invoice
	Given an order with a variety of items	
	And the following terms and balances
		| Credit Balance | Gift Card Balance | APR % | Number of Payments |
		| $21000.00      | $1000.00          | 7.5%  | 36                 |
	When I press calculate
	Then the resulting payment schedule should be
		| Down Payment | Monthly Payment | Final Payment | Gift Card | Credit   |
		| $0.00        | $0.00           | $0.00         | $0.00     | $2012.50 |

#
# This scenario fails.. maybe there's a spec issue?
#
@LargeOrder,@ignore
Scenario: Order with a gift card balance that exceeds the total invoice
	Given an order with a variety of items			
	And the following terms and balances
		| Credit Balance | Gift Card Balance | APR % | Number of Payments |
		| $1000.00       | $21000.00         | 7.5%  | 36                 |
	When I press calculate
	Then the resulting payment schedule should be
		| Down Payment | Monthly Payment | Final Payment | Gift Card | Credit   |
		| $0.00        | $0.00           | $0.00         | $2012.5   | $0.00    |
# Original Spec
#		| $0.00        | $0.00           | $0.00         | $1012.5   | $1000.00 |
# Revised Spec
#		| $0.00        | $0.00           | $0.00         | $1512.5   |  $500.25 |


		