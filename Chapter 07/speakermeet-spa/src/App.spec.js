import React from 'react';
import ReactDOM from 'react-dom';
import { expect } from 'chai';
 
import App from './App';
 
describe('(Component) App', () => {
  it('renders without crashing', () => {
    const div = document.createElement('div');
    ReactDOM.render(<App />, div);
  });
});
