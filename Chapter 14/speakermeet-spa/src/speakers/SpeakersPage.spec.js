import React from 'react';
import { expect } from 'chai';
import { mount, shallow } from 'enzyme';
import { SpeakersPage } from './SpeakersPage';

describe('Speakers Page', () => {
  it('exists', () => {
    expect(SpeakersPage).to.exist;
  });

  describe('Render', () => {
    beforeEach(() => {});

    it('renders', () => {
      // arrange
      const props = {
        speakers: [
          {
            id: 'test-speaker',
            firstName: 'Test',
            lastName: 'Speaker'
          }
        ]
      };

      // act
      const component = shallow(<SpeakersPage {...props} />);

      // assert
      expect(component.find('SpeakerList')).to.exist;
      expect(component.find('SpeakerList').props().speakers).to.deep.equal(props.speakers);
    });
  });  
});
