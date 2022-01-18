Feature: BigSmallWeb
	This feature is used to run all the test cases written in Documents
	https://www.bigsmall.in/ this link is tested using automation testing


@Initialize
Scenario: Open the BigSmall Website
	Given I open the website BigSmall
	Then the website is loaded properly

@Login
Scenario Outline: Login to the Bigsmall Website
	Given I open the website BigSmall
	And I click on signin button
	And I enter <email> and <password>
	Then the account is validated for <firstname> and <lastname>
	Examples: 
	| email              | password | firstname | lastname |
	| abenir99@gmail.com | abenir99 | Abe       | Nir      |
	| parvar75@gmail.com | parvar75 | Par       | Var      |
	| sanpav66@gmail.com | sanpav66 | San       | Pav      |


@signin
Scenario: signin to Bigsmall Website
	Given I open the website BigSmall
	And I click on signin button
	And I enter following details
	| Key       | Value              |
	| firstname | Dav                |
	| lastname  | Dra                |
	| email     | davdra99@gmail.com |
	| password  | davdra99           |
	Then the account  username is validated
	| Key       | Value               |
	| firstname | Dav                |
	| lastname  | Dra                 |


@search
Scenario Outline: search for product
	Given I open the website BigSmall
	And i search for <searchword> in the searchbox
	And i filter based on price from low to high
	Then get the number of products
	Examples: 
	| searchword  |
	| harrypotter |
	| naruto      |
	| mugs        |
	| keychains   |

@wishlist
Scenario: add product to wishlist
	Given I open the website BigSmall
	And i search for harrypotter in the searchbox
	And i filter based on price from low to high
	Then select the product and add to wishlist
	And add to cart from wishlist