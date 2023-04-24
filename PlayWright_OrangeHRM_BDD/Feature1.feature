Feature: Automating Complete website using PlayWright

A short summary of the feature

@SmokeTest
Scenario: Automating OrangeHRM website using Playwright
	Given Opening Website on Chromium
	Given Login with valid Credential and go to admin
	When Admin is open press add to add data
	And Add all the data one by one 
	Then Press SAVE and go to Username
	Then Add name of person in search
	And Press SEARCH
	Then Goto Pen symbol and Rename to new Name
	Then Press SAVE
	And Search Name that you Entered
	Then Press SEARCH
	Then Press DELETE
	And Confim the deletion
