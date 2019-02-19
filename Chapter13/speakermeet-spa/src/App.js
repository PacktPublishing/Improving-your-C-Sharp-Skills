import React, { Component } from 'react';
import { Switch, Route } from 'react-router-dom';
import logo from './logo.svg';
import Header from './common/Header';
import NotFound from './common/NotFound';
import SpeakersPage from './speakers/SpeakersPage';
import SpeakerDetailPage from './speakers/SpeakerDetailPage';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="container-fluid">
        <Header/>
        <main>
          <Switch>
            <Route exact path='/speakers/:id' component={SpeakerDetailPage}/>
            <Route exact path='/speakers' component={SpeakersPage}/>  
            <Route path='**' component={NotFound}/>          
          </Switch>
        </main>
      </div>
    );
  }
}

export default App;
