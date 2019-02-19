import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import { Provider } from 'react-redux';
import registerServiceWorker from './registerServiceWorker';
import configureStore from './store/configureStore';
import { getSpeakers } from './actions/speakerActions';
import 'bootstrap/dist/css/bootstrap.min.css';
import './index.css';
import factory from './services/serviceFactory';
import App from './App.js';

const store = configureStore();
store.dispatch(getSpeakers());

const speakers = [
  {
    id: 'clayton-hunt',
    firstName: 'Clayton',
    lastName: 'Hunt'
  },
  {
    id: 'john-callaway',
    firstName: 'John',
    lastName: 'Callaway'
  }
];

let service = factory.createSpeakerService();
speakers.forEach(speaker => {
  service.create(speaker);
});

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>,
  document.getElementById('root')
);

registerServiceWorker();
