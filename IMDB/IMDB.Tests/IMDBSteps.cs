﻿using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using IMDB;
using IMDB.Domain;
using TechTalk.SpecFlow.Assist;

namespace IMDB.Tests
{
    [Binding]
    class IMDBSteps
    {
        private string _actorName;
        private string _actorDOB;
        private string _producerName;
        private string _producerDOB;
        private string _movieName;
        private int _year;
        private string _plot;
        private string _actingIds;
        private int _producerId;
        private IMDBService _imdbService = new IMDBService();

    

        [Given(@"The actorname is ""(.*)""")]
        public void GivenTheActornameIs(string actorName)
        {
            _actorName = actorName;
        }

 

        [Given(@"the actor date of birth is ""(.*)""")]
        public void GivenTheActorDateOfBirthIs(string DOB)
        {
            _actorDOB = DOB;
        }


        [When(@"the actor is added")]
        public void WhenTheActorIsAdded()
        {
            _imdbService.AddActor(_actorName, _actorDOB);
        }
        [Then(@"the actor list should be")]
        public void ThenTheActorListShouldBe(Table table)
        {
            var actorList = _imdbService.GetActors();
            table.CompareToSet(actorList);
        }

       
        [Given(@"the producer name is  ""(.*)""")]
        public void GivenTheProducerNameIs(string producerName)
        {
            _producerName = producerName;
        }

        [Given(@"the prodcuer date of birth is ""(.*)""")]
        public void GivenTheProdcuerDateOfBirthIs(string DOB)
        {
            _producerDOB = DOB;
        }

     
        [When(@"the producer is added")]
        public void WhenTheProducerIsAdded()
        {
            _imdbService.AddProducer(_producerName, _producerDOB);
        }
        [Then(@"the producer list should be")]
        public void ThenTheProducerListShouldBe(Table table)
        {
            var producerList = _imdbService.GetProducers();
            table.CompareToSet(producerList);
        }

        [Given(@"I have a moviename ""(.*)""")]
        public void GivenIHaveAMoviename(string movieName)
        {
            _movieName = movieName;
        }

        [Given(@"The year of release is ""(.*)""")]
        public void GivenTheYearOfReleaseIs(int year)
        {
           _year=year;
        }

        [Given(@"The plot is ""(.*)""")]
        public void GivenThePlotIs(string plot)
        {
            _plot=plot;
        }

        [Given(@"the movie has actor ""(.*)""")]
        public void GivenTheMovieHasActor(string actorIds)
        {
             _actingIds = actorIds;
        }

        [Given(@"The movie has producer ""(.*)""")]
        public void GivenTheMovieHasProducer(int producerId)
        {
            _producerId = producerId;
        }

        [When(@"I add the movie")]
        public void WhenIAddTheMovie()
        {
            _imdbService.AddMovie(_movieName, _year, _plot, _actingIds, _producerId);
        }

        [Then(@"the movie list should be")]
        public void ThenTheMovieListShouldBe(Table table)
        {
            var movieList = _imdbService.GetMovies();
            table.CompareToSet(movieList);
        }

        [Then(@"the movieactor is as")]
        public void ThenTheMovieactorIsAs(Table table)
        {
            //var movieList = _imdbService.GetMovies();
            //var actingList=new List<Person>();
            
            
            //    actingList = movie.Actors;
            
            //table.CompareToSet(actingList);
        }

        [Then(@"the movieproducer is as")]
        public void ThenTheMovieproducerIsAs(Table table)
        {
          
        }


    }
}
