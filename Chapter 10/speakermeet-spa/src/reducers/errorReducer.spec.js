import { expect } from 'chai';
import { errorReducer } from './errorReducer';
import * as errorTypes from './errorTypes';
import * as actions from '../actions/speakerActions';


describe('Error Reducer', () => {
  it('exists', () => {
    expect(errorReducer).to.exist;
  });

  it('returns error state', () => {
    // arrange
    const initialState = [];
    const error = { type: errorTypes.SPEAKER_NOT_FOUND };
    const action = actions.getSpeakerFailure(error);
  
    // act
    const newState = errorReducer(initialState, action);
  
    // assert
    expect(newState).to.deep.equal([error]);
  });

  it('ignores duplicate errors', () => {
    // arrange
    const error = { type: errorTypes.SPEAKER_NOT_FOUND };
    const initialState = [error];
    const action = actions.getSpeakerFailure(error);
  
    // act
    const newState = errorReducer(initialState, action);
  
    // assert
    expect(newState).to.deep.equal([error]);
  });

  it('clears when a non-error action is received', () => {
    // arrange
    const error = { type: errorTypes.SPEAKER_NOT_FOUND };
    const initialState = [error];
    const action = { type: 'ANY_NON_ERROR' };
  
    // act
    const newState = errorReducer(initialState, action);
  
    // assert
    expect(newState).to.deep.equal([]);
  });
});
