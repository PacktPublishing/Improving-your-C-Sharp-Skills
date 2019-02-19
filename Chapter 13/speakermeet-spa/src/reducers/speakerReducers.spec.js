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

    it('sorts speakers by rank', () => {
      // arrange
      const initialState = [];
      const speaker1 = { id: 'test-speaker-1', firstName: 'Test 1', lastName: 'Speaker', rank: 1};
      const speaker2 = { id: 'test-speaker-2', firstName: 'Test 2', lastName: 'Speaker', rank: 2};
      const action = actions.getSpeakersSuccess([speaker1, speaker2]);
     
      // act
      const newState = speakersReducer(initialState, action);
     
      // assert
      expect(newState).to.have.lengthOf(2);
      expect(newState[0]).to.deep.equal(speaker2);
    });
  });
});
