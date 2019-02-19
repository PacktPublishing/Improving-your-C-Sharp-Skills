import { combineReducers } from 'redux';
import { speakersReducer, speakerReducer } from './speakerReducer';

const rootReducer = combineReducers({
  speakers: speakersReducer,
  speaker: speakerReducer
});

export default rootReducer;
