
declare @range int = 100;

declare @PrimeNo Table (
  
  PNo int
);

declare @n int = 5;
declare @isPrime bit = 1;

insert into @PrimeNo 
   values(2),
		 (3)

while ((select count(*) from @PrimeNo ) < @range)
  begin
    
	 set @isPrime = 1;

	  declare @count int = 0;
	  declare @x int = 0;

	  set @count = (select count(*) from @PrimeNo) 
	  declare @pNo int;
	  
	  while (@x < = @count)
	    begin
			
		    set @pNo = (select PNo from @PrimeNo 
			            order by PNo offset @x rows
						fetch next 1 rows only
					   )
			if(@n % @pNo = 0)
			  begin
			     set @isPrime = 0;
				 break;
			  end
			set @x= @x+1;
		end

		if(@isPrime = 1)
		   begin
		       insert into @PrimeNo
			    select @n
		   end
		    set @n= @n+2;
  end

Select * from @PrimeNo
