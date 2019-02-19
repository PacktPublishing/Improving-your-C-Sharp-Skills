import React from 'react';
import { expect } from 'chai';
import { mount, shallow } from 'enzyme';

import { SpeakerListRow } from './SpeakerListRow';

function setup(props) {
  const componentProps = {
    speaker: props.speaker || {}
  };

  return shallow(<SpeakerListRow {...componentProps} />);
}

describe('Speaker List Row', () => {
  it('exists', () => {
    expect(SpeakerListRow).to.exist;
  });

  describe('On Render', () => {
    it('renders a table row', () => {
      // arrange
      const component = setup({
        speaker: {
          id: 'test-speaker',
          firstName: 'Test',
          lastName: 'Speaker'
        }
      });

      // assert
      expect(component.find('.speaker-name').text()).to.equal('Test Speaker');
      expect(component.find('.speaker-link').props().to).to.equal('/speakers/test-speaker');
    });
  });
});
