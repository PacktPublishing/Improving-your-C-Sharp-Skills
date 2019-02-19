import React, { Component } from 'react';
import { connect } from 'react-redux';
import { bindActionCreators } from 'redux';
import * as speakerActions from '../actions/speakerActions';
import { SpeakerList } from './SpeakerList';

export class SpeakersPage extends Component {
  render() {
    return <SpeakerList speakers={this.props.speakers} />;
  }
}

function mapStateToProps(state) {
  return {
    speakers: state.speakers
  };
}

function mapDispatchToProps(dispatch) {
  return bindActionCreators(speakerActions, dispatch);
}

export default connect(mapStateToProps, mapDispatchToProps)(SpeakersPage);
