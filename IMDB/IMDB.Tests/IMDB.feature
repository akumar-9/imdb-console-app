Feature: IMDB
	
@addActor
Scenario: Adding an actor to repository
	Given The actorname is "Matt Damon"
	And the actor date of birth is "10-08-1970"
	When the actor is added
	Then the actor list should be
	| Name       | DOB        |
	| Matt Damon | 10-08-1970 |
	
	
@addProducer
Scenario: Adding a producer to repository
	Given the producer name is  "James Mangold"
	And the prodcuer date of birth is "12-16-1963"
	When the producer is added
    Then the producer list should be
	| Name          | DOB        |
	| James Mangold | 12-16-1963 |


@AddMovie
Scenario: Adding Movie
	Given I have a moviename "Ford V Ferrari"
	And The year of release is "2019"
	And The plot is "blah blah"
	And the movie has actor "1"
	And The movie has producer "1"
	When I add the movie
	Then the movie list should be 
	| Name           | YearOfRelease | Plot      | 
	| Ford V Ferrari | 2019          | blah blah |
	And the movieactor is as
	| Name       | DOB        |
	| Matt Damon | 08-10-1970 |
	And the movieproducer is as
	| Name          | DOB        |
	| James Mangold | 08-10-1970 |

@ListMovie
Scenario: Showing Movie
	Given I hace a moive repository
	When I fetch my movies
	Then The results shouble be
	| Name           | YearOfRelease | Plot      | 
	| Ford V Ferrari | 2019          | blah blah |
	And the movieactor is as
	| Name       | DOB        |
	| Matt Damon | 08-10-1970 |
	And the movieproducer is as
	| Name          | DOB        |
	| James Mangold | 08-10-1970 |

