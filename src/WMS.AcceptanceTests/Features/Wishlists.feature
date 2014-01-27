Feature: Wishlists
	In order to keep a list of items that interest me
	As a customer
	I want to create a wishlist

Background: 
	Given the following products
		|	Id	|	Name		|	Description				|	Price	|
		|	1	|	PS4			|	New PS4 Console			|	350		| 
		|	2	|	XBOX One	|	New Xbox One Console	|	430		|
		|	3	|	Battlefield	|	Battlefield 4			|	50		|

Scenario: Add product to wishlist
	When I Add 'PS4' to my wishlist
	Then my wishlist should show
		| Id | Name | Description		| Price |
		| 1  | PS4  | New PS4 Console	|	350	| 
		