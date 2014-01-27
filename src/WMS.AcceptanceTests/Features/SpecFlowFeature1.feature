Feature: Creating a wishlist
	In order to keep a list of items that interest me
	As a customer
	I want to create a wishlist


Scenario: Add item to wishlist
	Given I am on the products page
	When I select a product
	And I Add it to my wishlist
	Then it should be in my wishlist

