import * as types from './actionTypes';
import * as errors from './errorTypes';

export function errorReducer(state = [], action) {
  switch (action.type) {
    case types.GET_SPEAKER_FAILURE:
      let newState = [...state];

      if (newState.every(x => x.type !== action.error.type)) {
        newState.push(action.error);
      }

      return newState;
    default:
      return [];
  }
}
