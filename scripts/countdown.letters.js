function initialiseVowels() {
	let vowels =
		"a".repeat(15) +
		"e".repeat(21) +
		"i".repeat(13) +
		"o".repeat(13) +
		"u".repeat(5);
	return vowels.split('');
}

function initialiseConsonants() {
	let consonants =
		"b".repeat(2) +
		"c".repeat(3) +
		"d".repeat(6) +
		"f".repeat(2) +
		"g".repeat(3) +
		"h".repeat(2) +
		"j".repeat(1) +
		"k".repeat(1) +
		"l".repeat(5) +
		"m".repeat(4) +
		"n".repeat(8) +
		"p".repeat(4) +
		"q".repeat(1) +
		"r".repeat(9) +
		"s".repeat(9) +
		"t".repeat(9) +
		"v".repeat(1) +
		"w".repeat(1) +
		"x".repeat(1) +
		"y".repeat(1) +
		"z".repeat(1);
	return consonants.split('');
}

var vowels = initialiseVowels();
var consonants = initialiseConsonants();

function allTiles() {
	return [
		document.getElementById("letter1"),
		document.getElementById("letter2"),
		document.getElementById("letter3"),
		document.getElementById("letter4"),
		document.getElementById("letter5"),
		document.getElementById("letter6"),
		document.getElementById("letter7"),
		document.getElementById("letter8"),
		document.getElementById("letter9")
	];
}

function pickLetter(letters) {
	let idx = randomIntFromInterval(0, letters.length-1);
	let chosenLetter = letters.splice(idx, 1)[0];
	return chosenLetter;
}

function setTile(letter) {
	let tile = nextAvailableTile();
	if (!tile) {
		alert('All tiles are currently set. Remove some and try again');
		return;
	}
	tile.value = letter;
}

function pickConsonant() {
	let consonant = pickLetter(consonants);
	setTile(consonant);
}

function pickVowel() {
	let vowel = pickLetter(vowels);
	setTile(vowel);
}

function nextAvailableTile() {
	let tiles = allTiles();
	for(var tile of tiles) {
		if (tile.value === '') {
			return tile;
		}
	}
}

function resetTiles() {
	vowels = initialiseVowels();
	consonants = initialiseConsonants();
	clearTiles();
	clearSolution();
}

function clearTiles() {
	let tiles = allTiles();
	for(tile of tiles) {
		tile.value = '';
	}
}

function clearSolution() {
	let solutionDiv = document.getElementById('solutions');
	solutionDiv.innerHTML = '';
	solutionDiv.style.display = 'none';
}

// Fisher-Yates shuffle algorithm
function shuffle(a) {
    for (let i = a.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [a[i], a[j]] = [a[j], a[i]];
    }
    return a;
}

function luckyDip() {
	resetTiles();
	
	// Countdown rules state you must have between 3 and 5 vowels
	let vowelCount = randomIntFromInterval(3, 5);
	var chosenLetters = [];

	for (var i = 0; i < vowelCount; i++) {
		chosenLetters.push(pickLetter(vowels));
	}

	for (var i = chosenLetters.length; i < 9; i++) {
		chosenLetters.push(pickLetter(consonants));
	}

	shuffle(chosenLetters);

	for (var letter of chosenLetters) {
		setTile(letter);
	}
}

function lettersValid(lettersArray) {
	for (var letter of lettersArray) {
		// check all letters are provided and are single character between A and Z
		if (letter === '' || !/^[a-z]$/i.test(letter)) {
			return false;
		}
	}
	return true;
}

function getLettersSolutions() {
	let letter1 = document.getElementById("letter1").value;
	let letter2 = document.getElementById("letter2").value;
	let letter3 = document.getElementById("letter3").value;
	let letter4 = document.getElementById("letter4").value;
	let letter5 = document.getElementById("letter5").value;
	let letter6 = document.getElementById("letter6").value;
	let letter7 = document.getElementById("letter7").value;
	let letter8 = document.getElementById("letter8").value;
	let letter9 = document.getElementById("letter9").value;
	
	if (!lettersValid([letter1, letter2, letter3, letter4, letter5, letter6, letter7, letter8, letter9])) {
		alert("Please ensure selected letters are valid.")
		return;
	}
	
	var url = `https://countdownapitest.azurewebsites.net/api/letters/solve?letters=${letter1}&letters=${letter2}&letters=${letter3}&letters=${letter4}&letters=${letter5}&letters=${letter6}&letters=${letter7}&letters=${letter8}&letters=${letter9}`;
	makeCorsRequest(url);
}

function displayLettersSolutions(xhr) {
	let solutionPanel = document.getElementById('solutions');
	
	if (xhr.responseText === '{}') {
		solutionPanel.insertAdjacentHTML('beforeend', '<div>No words found for the provided letters.<br /></div>');
		solutionPanel.style.display = 'block';
		return;
	}
	
	let solutions = JSON.parse(xhr.responseText);
	solutionPanel.innerHTML = '';
	
	for(var i = 9; i > 0; i--) {
		let words = solutions[i];
		if (!words) {
			continue;
		}
		
		solutionPanel.insertAdjacentHTML('beforeend', `<div><strong>${i} letter words:</strong><br /></div>`);
		solutionPanel.insertAdjacentHTML('beforeend', '<div>');
		
		for (var word of words) {
			solutionPanel.insertAdjacentHTML('beforeend', `${word}<br />`);
		}
		
		solutionPanel.insertAdjacentHTML('beforeend', '<br /></div>');
	}
	solutionPanel.style.display = 'block';
}

document.getElementById('pickVowel').addEventListener('click', pickVowel);
document.getElementById('pickConsonant').addEventListener('click', pickConsonant);
document.getElementById('luckyDip').addEventListener('click', luckyDip);
document.getElementById('clearTiles').addEventListener('click', resetTiles);
document.getElementById('getSolutions').addEventListener('click', getLettersSolutions);