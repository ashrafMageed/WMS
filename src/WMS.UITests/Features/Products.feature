Feature: Products
	In order to shop
	As a customer
	I want to be able to view products

Background: 
	Given I have the following products
		|	Id	|	Name		|	Description				|	Price	|
		|	1	|	PS4			|	New PS4 Console			|	350		| 
		|	2	|	XBOX One	|	New Xbox One Console	|	430		|
		|	3	|	Battlefield	|	Battlefield 4			|	50		|

Scenario: View Products
	When I navigate to the products page
	Then I should see all products