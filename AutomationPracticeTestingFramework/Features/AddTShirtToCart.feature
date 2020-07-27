Feature: AddTShirtToCart
	In order to add a T-Shirt to the cart
	As a customer
	I want to see the T-Shirt in the cart

@Firefox
Scenario: Go to the tshirts page - Firefox
	Given I am on the home page
	When I click on the tshirt
	And have waited for the page to load
	Then the URL should be "http://automationpractice.com/index.php?id_product=1&controller=product"

@Chrome
Scenario: Go to the tshirts page - Chrome
	Given I am on the home page
	When I click on the tshirt
	And have waited for the page to load
	Then the URL should be "http://automationpractice.com/index.php?id_product=1&controller=product"

@Firefox
Scenario: Select medium size - Firefox
	Given I am on the tshirt item page
	When I click on the M size in the size combobox
	Then The url should contain "size-m"

@Chrome
Scenario: Select medium size - Chrome
	Given I am on the tshirt item page
	When I click on the M size in the size combobox
	Then The url should contain "size-m"

@Firefox
Scenario: Select Blue colour - Firefox
	Given I am on the tshirt item page
	When I click on blue colour option
	Then The url should contain "color-blue"

@Chrome
Scenario: Select Blue colour - Chrome
	Given I am on the tshirt item page
	When I click on blue colour option
	Then The url should contain "color-blue"

@Firefox
Scenario: Cart has the correct price rows - Firefox
	Given I am on the tshirt item page
	When I click on the add to cart button
	And have waited for the page to load
	Then The rows of the cart price should be:
		| rows                  |
		| Total products $16.51 |
		| Total shipping  $2.00 |
		| Total $18.51          |

@Chrome
Scenario: Cart has the correct price rows - Chrome
	Given I am on the tshirt item page
	When I click on the add to cart button
	And have waited for the page to load
	Then The rows of the cart price should be:
		| rows                  |
		| Total products $16.51 |
		| Total shipping  $2.00 |
		| Total $18.51          |

@Firefox
Scenario: Add tshirt to cart - Firefox
	Given I am on the tshirt item page
	When I click on the add to cart button
	And have waited for the page to load
	Then There should be "1" item in the cart

@Chrome
Scenario: Add tshirt to cart - Chrome
	Given I am on the tshirt item page
	When I click on the add to cart button
	And have waited for the page to load
	Then There should be "1" item in the cart

@Firefox
Scenario: Change quantity to 2 - Firefox
	Given I am on the tshirt item page
	When I click on increase quantity
	Then There should be <result> item in the quantity text box

	Examples:
		| result |
		| 2      |

@Chrome
Scenario: Change quantity to 2 - Chrome
	Given I am on the tshirt item page
	When I click on increase quantity
	Then There should be <result> item in the quantity text box

	Examples:
		| result |
		| 2      |

@Firefox
Scenario: Set item quantity - Firefox
	Given I am on the tshirt item page
	And I have entered <num1> into the quantity
	When I click on the add to cart button
	Then There should be <result> item in the quantity text box

	Examples:
		| num1 | result |
		| 3    | 3      |
		| 4    | 4      |
		| 5    | 5      |

@Chrome
Scenario: Set item quantity - Chrome
	Given I am on the tshirt item page
	And I have entered <num1> into the quantity
	When I click on the add to cart button
	Then There should be <result> item in the quantity text box

	Examples:
		| num1 | result |
		| 3    | 3      |
		| 4    | 4      |
		| 5    | 5      |

@Firefox
Scenario: Add 0 items to the cart - Firefox
	Given I am on the tshirt item page
	And I have entered "0" into the quantity
	When I click on the add to cart button
	Then There should be an error message saying "Null quantity."

@Chrome
Scenario: Add 0 items to the cart - Chrome
	Given I am on the tshirt item page
	And I have entered "0" into the quantity
	When I click on the add to cart button
	Then There should be an error message saying "Null quantity."

@Firefox
Scenario: Remove the item from the cart - Firefox
	Given I am on the tshirt item page
	And I have added the tshirt to the cart
	And have waited for the page to load
	And I have closed the popup window
	When I click on the remove button from the cart
	And have waited for the page to load
	Then The cart should be empty
	
@Chrome
Scenario: Remove the item from the cart - Chrome
	Given I am on the tshirt item page
	And I have added the tshirt to the cart
	And have waited for the page to load
	And I have closed the popup window
	When I click on the remove button from the cart
	And have waited for the page to load
	Then The cart should be empty