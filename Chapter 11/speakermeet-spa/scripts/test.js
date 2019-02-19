'use strict';

import { JSDOM } from 'jsdom';
import fetchPonyfill from 'fetch-ponyfill';
import Enzyme from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';

const { fetch } = fetchPonyfill();

const jsdom = new JSDOM('<!doctype html><html><body></body></html>');
const { window } = jsdom;
window.fetch = window.fetch || fetch;

global.window = window;
global.document = window.document;
global.fetch = window.fetch;
global.navigator = window.navigator;

function noop() {
  return {};
}

// prevent mocha tests from breaking when trying to require a css file
require.extensions['.css'] = noop;
require.extensions['.svg'] = noop;

Enzyme.configure({ adapter: new Adapter() });
