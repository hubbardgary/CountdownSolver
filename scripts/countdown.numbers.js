function largeNums() {
	return [25, 50, 75, 100];
}

function smallNums() {
	return [1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10];
}

function setTarget() {
	let targetTxt = document.getElementById('target');
	
	var count = 0;
	var iv = setInterval(function() {
		targetTxt.value = randomIntFromInterval(100, 999);
		if (count++ == 100) {
			clearInterval(iv);
		}
	}, 1);
}

function pickNumbers(largeNumCount) {
	var large = largeNums();
	var small = smallNums();
	var chosenNums = [];
	
	for(var i = 0; i < largeNumCount; i++) {
		let idx = randomIntFromInterval(0, large.length-1);
		chosenNums.push(large.splice(idx, 1)[0]);
	}
	
	for(var i = chosenNums.length; i < 6; i++) {
		let idx = randomIntFromInterval(0, small.length-1);
		chosenNums.push(small.splice(idx, 1)[0]);
	}
	
	displayNumbers(chosenNums.sort((a, b) => b - a)); // sort descending
}

function displayNumbers(nums) {
	document.getElementById('num1').value = nums[0];
	document.getElementById('num2').value = nums[1];
	document.getElementById('num3').value = nums[2];
	document.getElementById('num4').value = nums[3];
	document.getElementById('num5').value = nums[4];
	document.getElementById('num6').value = nums[5];
}

function numsValid(numsArray) {
	for (var i of numsArray) {
		if (i === '' || isNaN(i) || i.length > 3) {
			return false;
		}
	}
	return true;
}

function getNumbersSolutions() {
	let num1 = document.getElementById('num1').value;
	let num2 = document.getElementById('num2').value;
	let num3 = document.getElementById('num3').value;
	let num4 = document.getElementById('num4').value;
	let num5 = document.getElementById('num5').value;
	let num6 = document.getElementById('num6').value;
	let target = document.getElementById('target').value;
	
	if (!numsValid([num1, num2, num3, num4, num5, num6, target])) {
		alert('Please ensure selected numbers and target are valid.')
		return;
	}
	
	var url = `http://localhost:49730/api/numbers/solve/${target}?nums=${num1}&nums=${num2}&nums=${num3}&nums=${num4}&nums=${num5}&nums=${num6}`;
	makeCorsRequest(url);
}

function displayNumbersSolutions(xhr) {
	var responseJson = JSON.parse(xhr.responseText);
		
	let solutions = responseJson.solutions;
	let solutionPanel = document.getElementById('solutions');
	
	solutionPanel.innerHTML = '';
	
	if (responseJson.distanceFromTarget === 0) {
		solutionPanel.insertAdjacentHTML('beforeend', `<div><strong>Solved! Showing ${responseJson.solutions.length} solutions.</strong><br /></div>`);
	} else {
		solutionPanel.insertAdjacentHTML('beforeend', `<div><strong>No solutions found. The closest is ${responseJson.distanceFromTarget} away</strong><br /></div>`);
	}
	
	for (var solution of solutions) {
		solutionPanel.insertAdjacentHTML('beforeend', `<div>${solution.replace(/\r\n/g, '<br />')}<br /></div>`);
	}
	solutionPanel.style.display = 'block';
}

document.getElementById('allSmall').addEventListener('click', function() { pickNumbers(0); });
document.getElementById('oneLarge').addEventListener('click', function() { pickNumbers(1); });
document.getElementById('twoLarge').addEventListener('click', function() { pickNumbers(2); });
document.getElementById('threeLarge').addEventListener('click', function() { pickNumbers(3); });
document.getElementById('fourLarge').addEventListener('click', function() { pickNumbers(4); });
document.getElementById('setTarget').addEventListener('click', setTarget);
document.getElementById('getSolutions').addEventListener('click', getNumbersSolutions);