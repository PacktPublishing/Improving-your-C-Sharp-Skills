'use strict';

import jsdom from 'jsdom';
import Enzyme from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';

global.document = jsdom.jsdom('<html><body></body></html>');
global.window = document.defaultView;
global.navigator = window.navigator;

function noop() {
  return {};
}

// prevent mocha tests from breaking when trying to require a css file
require.extensions['.css'] = noop;
require.extensions['.svg'] = noop;

Enzyme.configure({ adapter: new Adapter() });
