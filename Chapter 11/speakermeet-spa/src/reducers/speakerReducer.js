import * as types from './actionTypes';

export function speakersReducer(state = [], action) {
  switch (action.type) {
    case types.GET_SPEAKERS_SUCCESS:
      return action.speakers;
    default:
      return state;
  }
}

export function speakerReducer(
  state = {
    id: '',
    firstName: '',
    lastName: ''
  },
  action
) {
  switch (action.type) {
    case types.GET_SPEAKER_SUCCESS:
      return action.speaker;
    default:
      return state;
  }
}
