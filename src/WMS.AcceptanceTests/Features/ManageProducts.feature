Feature: ManageProducts
	In order to administer the site
	As a site administrator
	I want to manage products
#
#Background: 
#	Given I have the following products
#		| Id | Name        | Description          | Price | Category |
#		| 1  | PS4         | New PS4 Console      | 350   | Console  |
#		| 2  | XBOX One    | New Xbox One Console | 430   | Console  |
#		| 3  | Battlefield | Battlefield 4        | 50    | Game     |

Scenario: Add a product
	Given the following product information
		|	Name		| Description   | Price	| Category	|
		| Call of Duty	| COD: Ghosts	| 54.99 | Game		|
	When I create the product
	Then it should be added to the list of products
