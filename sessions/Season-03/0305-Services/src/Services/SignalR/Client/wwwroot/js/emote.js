export function flyEmote(buttonId) {

	var newImg = document.createElement("img");
	newImg.src = `/img/${buttonId}.png`;
	newImg.className = "float";
	newImg.style.bottom = "-30px";
	newImg.style.left = `${Math.random() * 100}%`;
	document.body.appendChild(newImg);

}

export function start() {

	window.setInterval(function () {

		var top = document.body.clientHeight - 500 - 100;

		var hiddenEls = document.querySelectorAll("img");
		hiddenEls.forEach(h => {
			if (top > h.offsetTop) document.body.removeChild(h);
		});

	}, 2000);

}