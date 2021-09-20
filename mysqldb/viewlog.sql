select *, SUBSTRING(argument,1,2500) from mysql.general_log order by event_time desc;


/*SET global general_log = 1;
SET global log_output = 'table';*/