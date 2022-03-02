
create table company_categories(
	  id uuid default uuid_generate_v4() primary key
	, name varchar(200) not null
	, description varchar(600)
	, created_at timestamp with time zone default CURRENT_TIMESTAMP not null
	, deleted_at timestamp with time zone
); 
