
create table boards (
	  id uuid default uuid_generate_v4() primary key
	, user_id varchar(100) not null
	, name varchar(100) not null
	, description varchar(300)
	, created_at timestamp with time zone default CURRENT_TIMESTAMP not null
	, deleted_at timestamp with time zone
); 

create table board_item (
	  id uuid default uuid_generate_v4() primary key
	, board_id uuid references boards(id) not null
	, name varchar(100) not null
	, finished bool not null
	, amount int not null
	, unit_price decimal(10,2) 
	, created_at timestamp with time zone default CURRENT_TIMESTAMP not null
	, deleted_at timestamp with time zone
); 
