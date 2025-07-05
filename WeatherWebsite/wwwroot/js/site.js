const updateTime = () => {
    let timeZone = document.getElementById('timeZone').value;

    if (timeZone) {
        // Get the current time in UTC
        let now = new Date();
        let options = {
            timeZone: timeZone,
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit',
            hour12: false
        };
        let formatter = new Intl.DateTimeFormat([], options);
        let parts = formatter.formatToParts(now);
        let hour = parts.find(p => p.type === 'hour').value;
        let minute = parts.find(p => p.type === 'minute').value;
        let second = parts.find(p => p.type === 'second').value;

        hour = parseInt(hour);
        minute = parseInt(minute);
        second = parseInt(second);

        let hourDegrees = ((hour / 12) * 360) + ((minute / 60) * 30) + 90;
        let minuteDegrees = ((minute / 60) * 360) + ((second / 60) * 6) + 90;
        let secondDegrees = ((second / 60) * 360) + 90;

        document.querySelector('.hour-hand').style.transform = `rotate(${hourDegrees}deg)`;
        document.querySelector('.minute-hand').style.transform = `rotate(${minuteDegrees}deg)`;
        document.querySelector('.second-hand').style.transform = `rotate(${secondDegrees}deg)`;

        let currentTimeString = formatter.format(now);
        document.getElementById('currentTime').textContent = currentTimeString;
    }
    else {
        document.getElementById('currentTime').textContent = '';
        document.querySelector('.hour-hand').style.transform = 'rotate(90deg)';
        document.querySelector('.minute-hand').style.transform = 'rotate(90deg)';
        document.querySelector('.second-hand').style.transform = 'rotate(90deg)';
    }
}

updateTime();
setInterval(updateTime, 1000);