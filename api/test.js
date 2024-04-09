async function getDatafromApi() {
	try {
		const fetch = await import('node-fetch');
		const response = await fetch.default('https://last-airbender-api.fly.dev/api/v1/characters/random');
		const json = await response.json();
		// Maybe console log the json here check the data structure
		console.log(json[0].name);
	}
	catch (error) {
		console.error('Failed to fetch', error);
		return 'error';
	}
}

getDatafromApi();