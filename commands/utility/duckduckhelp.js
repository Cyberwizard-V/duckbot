const { SlashCommandBuilder, EmbedBuilder } = require('discord.js');

module.exports = {
	// eslint-disable-next-line no-dupe-keys
	data: new SlashCommandBuilder()
		.setName('duckduckhelp')
		.setDescription('Replies with duck commands'),
	// eslint-disable-next-line no-dupe-keys
	async execute(interaction) {
		try {
			const embed = new EmbedBuilder()
				.setColor(0x0099FF)
				.setTitle('**Duck Info**')
				.setAuthor({ name: '🦆 Duck Help 🦆', iconURL: 'https://i.imgur.com/ryjpL39.png' })
				.setDescription('When you use the `/duckduckhelp` command, DuckBot responds with a list of available commands and their descriptions to assist you in using DuckBot effectively. Below is the structure of the commands:')
				.setThumbnail('https://i.imgur.com/ryjpL39.png')
				.addFields(
					{ name: 'Command List', value: '**/duckduckgif** - Replies with a duck GIF\n**/duckduckquote** - Replies with a duck quote\n**/quack** - Replies with a QUACK (duh)' },
					{ name: '\u200B', value: '\u200B' },
				)
				.setImage('https://i.imgur.com/kpzEH6e.png')
				.setTimestamp()
				.setFooter({ text: 'Quack Commands', iconURL: 'https://i.imgur.com/ryjpL39.png' });

			await interaction.reply({ embeds: [embed] });
		}
		catch (error) {
			console.error(error);
			await interaction.reply('SORRY! SEEMS LIKE THE API IS NOT WORKING?!');
		}
	},
};