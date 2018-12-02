// Create the XHR object.
function createCORSRequest(method, url) {
	var xhr = new XMLHttpRequest();
	if ('withCredentials' in xhr) {
		// XHR for Chrome/Firefox/Opera/Safari.
		xhr.open(method, url, true);
	} else if (typeof XDomainRequest != 'undefined') {
		// XDomainRequest for IE.
		xhr = new XDomainRequest();
		xhr.open(method, url);
	} else {
		// CORS not supported.
		xhr = null;
	}
	return xhr;
}

// Make the actual CORS request.
function makeCorsRequest(url) {
	// This is a sample server that supports CORS.
	var xhr = createCORSRequest('GET', url);
	if (!xhr) {
		alert('CORS not supported');
		return;
	}

	// Response handlers.
	xhr.onload = function() {
		displaySolutions(xhr);
		$('body').removeClass('loading');
	};
	

	xhr.onerror = function() {
		alert('No solutions found, There was an error making the request.');
		$('body').removeClass('loading');
	};

	$('body').addClass('loading');
	xhr.send();
}

function displaySolutions(xhr) {
	if (xhr.status !== 200) {
		alert(`An error occurred when attempting to solve: ${xhr.responseText}`);
	} else if(xhr.responseURL.indexOf('api/numbers') > 0) {
		displayNumbersSolutions(xhr);
	} else if(xhr.responseURL.indexOf('api/letters') > 0) {
		displayLettersSolutions(xhr);
	}
}

function randomIntFromInterval(min, max) {
	return Math.floor(Math.random() * (max - min + 1) + min);
}