import { expect } from 'chai';

describe('Test Framework', () => {
  it('is configured correctly', () => {
    expect(1).to.equal(1);
  });
});

describe('Is Palindrome', () => {
  it('exists', () => {
    expect(isPalindrome).to.exist;
  });

  it('a single letter is a palindrome', () => {
    // arrange
    const value = 'a';

    // act
    const result = isPalindrome(value);

    // assert
    expect(result).to.be.true;
  });

  it('two non-matching letters is not a palindrome', () => {
    // arrange
    const value = 'at';

    // act
    const result = isPalindrome(value);

    // assert
    expect(result).to.be.false;
  });

  it('two matching letters are a palindrome', () => {
    // arrange
    const value = 'oo';

    // act
    const result = isPalindrome(value);

    // assert
    expect(result).to.be.true;
  });

  it('three letter palindrome', () => {
    // arrange
    const value = 'mom';

    // act
    const result = isPalindrome(value);

    // assert
    expect(result).to.be.true;
  });

  it('four letter palindrome', () => {
    // arrange
    const value = 'abba';
   
    // act
    const result = isPalindrome(value);
   
    // assert
    expect(result).to.be.true;
  });
});

function isPalindrome(value) {
  if (value.length === 1) {
    return true;
  }

  if (value.length === 2 && value[0] === value[1]) {
    return true;
  }

  if (value[0] === value[value.length - 1]) {
    return isPalindrome(value.substring(1, value.length - 1));
  }

  return false;
}
