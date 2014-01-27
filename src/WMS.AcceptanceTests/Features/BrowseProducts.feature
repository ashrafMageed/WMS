Feature: BrowseProducts
	In order to shop
	As a customer
	I want to be to view products

Background: 
	Given I have the following products
		|	Id	|	Name		|	Description				|	Price	|
		|	1	|	PS4			|	New PS4 Console			|	350		| 
		|	2	|	XBOX One	|	New Xbox One Console	|	430		|
		|	3	|	Battlefield	|	Battlefield 4			|	50		|

Scenario: Show all products
	When I view products
	Then I should see all products
