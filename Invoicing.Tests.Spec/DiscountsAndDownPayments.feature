Feature: Discounts and Down Payments
	In order to see what my payments are
	As a customer
	I want to calculate a schedule based off of my order

@customOrder
Scenario: Order with a single item, no discounts, credits, or gift cards
	Given an order with the following items
		| Product                  | Price   | Upfront % | Discount % | Quantity |
		| Flexible whisker sensors | $100.00 | 0%        | 0%         | 100      |
	And the following terms and balances
		| Credit Balance | Gift Card Balance | APR % | Number of Payments |
		| $0.00          | $0.00             | 0%    | 10                 |
	When I press calculate
	Then the resulting payment schedule should be
		| Down Payment | Monthly Payment | Final Payment | Gift Card | Credit |
		| $0           | $1000.00        | $1000.00      | $0        | $0     |

@customOrder		
Scenario: Order with multiple items, no discounts, credits, or gift cards
	Given an order with the following items
		| Product                     | Price   | Upfront % | Discount % | Quantity |
		| Flexible whisker sensors    | $100.00 | 0%        | 0%         | 100      |
		| Assorted Gears and Bearings | $50.00  | 0%        | 0%         | 100      |
	And the following terms and balances
		| Credit Balance | Gift Card Balance | APR % | Number of Payments |
		| $0.00          | $0.00             | 0%    | 10                 |
	When I press calculate
	Then the resulting payment schedule should be
		| Down Payment | Monthly Payment | Final Payment | Gift Card | Credit |
		| $0           | $1500.00        | $1500.00      | $0        | $0     |

@customOrder
Scenario: Order with multiple items, discounts, credits, and gift cards
	Given an order with the following items
		| Product                       | Price   | Upfront % | Discount % | Quantity |
		| Flexible whisker sensors      | $100.00 | 0%        | 10%        | 100      |
		| Assorted Gears and Bearings   | $50.00  | 0%        | 0%         | 100      |
		| Mountable Halogen Floodlights | 100     | 10%       | 5%         | 50       |
		
	And the following terms and balances
		| Credit Balance | Gift Card Balance | APR % | Number of Payments |
		| $100.00        | $50.00            | 7.5%  | 36                 |
	When I press calculate
	Then the resulting payment schedule should be
		| Down Payment | Monthly Payment | Final Payment | Gift Card | Credit |
		| $349.75      | $541.96         | $541.69       | $0        | $0     |
# original spec
#		| $349.75      | $541.96         | $541.69       | $0        | $0     |
# revised spec
#		| $399.75      | $540.57         | $540.28       | $0        | $0     |

