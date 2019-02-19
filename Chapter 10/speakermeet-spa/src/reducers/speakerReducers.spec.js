import { expect } from 'chai';
import * as actions from '../actions/speakerActions';
import * as types from './actionTypes';
import { speakersReducer, speakerReducer } from './speakerReducer';

describe('Speaker Reducers', () => {
  describe('Speakers Reducer', () => {
    it('exists', () => {
      expect(speakersReducer).to.exist;
    });

    it('Loads Speakers', () => {
      // arrange
      const initialState = [];

      const speaker = {
        id: 'test-speaker',
        firstName: 'Test',
        lastName: 'Speaker'
      };
      const action = actions.getSpeakersSuccess([speaker]);

      // act
      const newState = speakersReducer(initialState, action);

      // assert
      expect(newState).to.have.lengthOf(1);
      expect(newState[0]).to.deep.equal(speaker);
    });
  });

  describe('Speaker Reducer', () => {
    it('exists', () => {
      expect(speakerReducer).to.exist;
    });

    it('gets a speaker', () => {
      // arrange
      const initialState = { id: '', firstName: '', lastName: '' };
      const speaker = { id: 'test-speaker', firstName: 'Test', lastName: 'Speaker'};
      const action = actions.getSpeakerSuccess(speaker);
    
      // act
      const newState = speakerReducer(initialState, action);
    
      // assert
      expect(newState).to.deep.equal(speaker);
    });
  });
});
