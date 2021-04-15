Feature: SpecFlowFeature1
	User wants to get access to most often used features in the Epam application

@smoke
Scenario Outline: User views the navigation rows
	Given I am on the Home Page 
	When I see '<Header>' in the navigation table
	Then a '<Header>' is displayed on Home Page

	Examples: 
| Header            |
| Services          | 
| How We Do It      |
| Our Work          |
| Insights          |
| About             |
| Careers           |

@smoke
Scenario Outline:  User search by params 
	Given I am on the Home Page 
	When I click search button
	And I enter '<Header>' in the search field
	And I click on Find button on the search popup
	Then '<Header>' header should be displayed on the Search Page
	Examples: 
| Header          |
| Automation      |

@smoke
Scenario Outline:User views the Services Page
	Given I am on the Home Page 
	When I click on '<Header>' in the navigation table
	Then '<text>' should be displayed on Services Page
	Examples: 
 | Header    | text                                                                                                                                                 |
 |Services   |By fusing consulting talent with engineering expertise, we’re able to integrate vision and execution so you can quickly move from strategy to reality.|

@smoke
Scenario Outline: User  views The Epam Home page
	Given I am on the Home Page
	When I click on localtion button
	And I switch to RU language
	Then the following menu items should be displayed:
	"""
	РЕШЕНИЯ И ПРОЕКТЫ, О НАС, КАРЬЕРА В EPAM
	"""