import { expect } from 'chai';
import React from 'react';
import { mount } from 'enzyme';
import { SpeakerDetailPage } from './SpeakerDetailPage';

describe('Speaker Detail Page', () => {
  it('exists', () => {
    expect(SpeakerDetailPage).to.exist;
  });

  describe('Render', () => {
    it('renders', () => {
      // arrange
      const props = {
        match: { params: { id: 'test-speaker' } },
        actions: {
          getSpeaker: id => {
            return Promise.resolve();
          }
        },
        speaker: { firstName: 'Test' }
      };

      // act
      const component = mount(<SpeakerDetailPage {...props} />);

      // assert
      expect(component.find('#first-name').text()).to.contain('Test');
    });
  });
});
