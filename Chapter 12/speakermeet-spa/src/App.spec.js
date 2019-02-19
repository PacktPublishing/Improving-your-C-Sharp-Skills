import React from 'react';
import { expect } from 'chai';
import { shallow } from 'enzyme';

import App from './App';

describe('(Component) App', () => {
  it('renders without crashing', () => {
    const div = document.createElement('div');
    shallow(<App />, div);
    expect(1).to.equal(1);
  });
});
