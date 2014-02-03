Feature: BrowseProducts
	In order to shop
	As a customer
	I want to be able to browse products

Background: 
	Given I have the following products
		| Id | Name        | Description          | Price | Category |
		| 1  | PS4         | New PS4 Console      | 350   | Console  |
		| 2  | XBOX One    | New Xbox One Console | 430   | Console  |
		| 3  | Battlefield | Battlefield 4        | 50    | Game     |

Scenario: Browse products by category
	When I select 'Console' product category
	Then I should see
			| Id | Name     | Description          | Price | Category |
			| 1  | PS4      | New PS4 Console      | 350   | Console  |
			| 2  | XBOX One | New Xbox One Console | 430   | Console  |

Scenario: Browse products by price range
	When I filter products by a price range from '50' to '400'
	Then I should see
			| Id | Name			| Description          | Price | Category |
			| 1  | PS4			| New PS4 Console      | 350   | Console  |
			| 3  | Battlefield	| Battlefield 4     | 50    | Game     |