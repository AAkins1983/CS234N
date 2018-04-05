DECLARE

CURSOR cur_emp IS
SELECT empno, sal
FROM employee
WHERE job <> 'PRESIDENT'// 
FOR UPDATE NOWAIT;
lv_cursal_num NUMBER(6);
lv_raise_num NUMBER(6);
lv_newsal_num NUMBER(6);
lv_salinc_num NUMBER(6);

BEGIN

FOR rec_emp IN cur_emp LOOP
lv_cursal_num := rec_emp.sal * 12;
lv_raise_num := rec_emp.sal * 12 * .06;
lv_newsal_num := lv_cursal_num + lv_raise_num;
IF lv_raise_num > 2000 THEN
lv_raise_num := 2000;
lv_newsal_num := lv_cursal_num + lv_raise_num;

END IF;
--UPDATE employee SET sal = lv_newsal_num/12 WHERE CURRENT OF cur_emp;
Dbms_Output.put_line('Emp no: ' || rec_emp.empno ||' Current Annual Salary: ' || lv_cursal_num ||
' Salary Raise: ' ||lv_raise_num||' Proposed New Annual Salary: '||lv_newsal_num);
END LOOP;

END;

tot_raise := tot_raise + lv_raise_num; -- place inside LOOP