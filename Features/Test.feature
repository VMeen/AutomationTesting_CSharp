@feature
Feature: MyAccount
	In order to use all funcionalities
	As a user
	I want to be able to create my account

@registration
 Scenario: 01 user can create an account
		Given user opens sign in page 
		And initiates a flow for creating an account
		And user enters all required personal details
		When sbumits the sign up form
		Then user will be logged in 
		And User's full name will be displayed

@logout
 Scenario: 02 user can log out
	Given user lands on the logged on page 
	When user logout
	Then sign in page is opened

@login
 Scenario: 03 user can log in
	Given user opens authentication page 
	And enters correct credentials
	When user submits the login form
	Then user will be logged in

@Cart
 Scenario: 04 user can add products to cart
	Given user adds product to cart from dress section	
	When user proceeds to checkout and continue till payments
	Then on the payments page verify the product details are correct