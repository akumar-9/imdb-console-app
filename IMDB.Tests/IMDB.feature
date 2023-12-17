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
	And the prodcuer date of birth is "16-12-1963"
	When the producer is added
    Then the producer list should be
	| Name          | DOB        |
	| James Mangold | 16-12-1963 |


@AddMovie
Scenario: Adding Movie
	Given I have a moviename "Ford V Ferrari"
	And The year of release is "2019"
	And The plot is "vroom vroom yay yay"
	And the movie has actor "1 2"
	And The movie has producer "1"
	When I add the movie
	Then the movie list should be 
	| Name           | YearOfRelease | Plot                |
	| Ford V Ferrari | 2019          | vroom vroom yay yay |
	And the movieactor is as
	| Name           | DOB        |
	| Matt Damon     | 08-10-1970 |
	| Christian Bale | 30-01-1974 |

	And the movieproducer is as
	| Name          | DOB        |
	| James Mangold | 16-12-1963 |

@ListMovie
Scenario: Showing Movie
	Given I hace a moive repository
	When I fetch my movies
	Then The results shouble be
	| Name           | YearOfRelease | Plot                  |
	| Ford V Ferrari | 2019          | vroom vroom yay yay   |
	| Hobbs and Shaw | 2019          | vroom vroom bang bang |  
	And the movieactor is as
	| Name           | DOB        |
	| Matt Damon     | 08-10-1970 |
	| Christian Bale | 30-01-1974 |
	| Dwayne Johnson | 02-05-1972 |
	| Jason Statham  | 26-07-1967 |

	And the movieproducer is as
	| Name          | DOB        |
	| James Mangold | 16-12-1963 |
	| Chris Morgan  | 24-11-1966 |

