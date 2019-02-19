import { expect } from 'chai';
import React from 'react';
import { shallow } from 'enzyme';
import { SpeakerList } from './SpeakerList';

describe('Speaker List', () => {
  it('exists', () => {
    expect(SpeakerList).to.exist;
  });

  describe('On Render', () => {
    describe('No Speakers Exist', () => {
      it('renders no speakers message', () => {
        // arrange
        const speakers = [];

        // arrange
        const component = setup({ speakers })

        // assert
        expect(component.find('#no-speakers').text()).to.equal('No Speakers Available.');
      });
    });

    describe('Speakers Exist', () => {
        it('renders a table when speakers exist', () => {
          // arrange
          const speakers = [{
            id: 'test-speaker-1',
            firstName: 'Test',
            lastName: 'Speaker 1'
          }, {
            id: 'test-speaker-2',
            firstName: 'Test',
            lastName: 'Speaker 2'
          }];
      
          // act
          const component = setup({speakers});
      
          // assert        
          expect(component.find('.speakers').children()).to.have.lengthOf(2);
          expect(component.find('.speakers').childAt(0).type().name).to.equal('SpeakerListRow');
        });
      });
  });
});

function setup(props) {
  const componentProps = {
    speakers: props.speakers || []
  };

  return shallow(<SpeakerList {...componentProps} />);
}
