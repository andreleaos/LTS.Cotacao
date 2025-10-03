-- 03_seed_quotes_sept_2025.sql (versão simples: 30 INSERTs/REPLACEs)

-- Dia 01
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-01',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(1/3.0) * 1.5) + (COS(1/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(1/3.0) * 1.5) + (COS(1/2.0) * 0.7) + 0.8 + (1 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(1/3.0) * 1.5) + (COS(1/2.0) * 0.7) - 0.9 - (1 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((1+1)/3.0) * 1.5) + (COS((1+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (1 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 02
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-02',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(2/3.0) * 1.5) + (COS(2/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(2/3.0) * 1.5) + (COS(2/2.0) * 0.7) + 0.8 + (2 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(2/3.0) * 1.5) + (COS(2/2.0) * 0.7) - 0.9 - (2 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((2+1)/3.0) * 1.5) + (COS((2+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (2 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 03
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-03',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(3/3.0) * 1.5) + (COS(3/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(3/3.0) * 1.5) + (COS(3/2.0) * 0.7) + 0.8 + (3 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(3/3.0) * 1.5) + (COS(3/2.0) * 0.7) - 0.9 - (3 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((3+1)/3.0) * 1.5) + (COS((3+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (3 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 04
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-04',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(4/3.0) * 1.5) + (COS(4/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(4/3.0) * 1.5) + (COS(4/2.0) * 0.7) + 0.8 + (4 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(4/3.0) * 1.5) + (COS(4/2.0) * 0.7) - 0.9 - (4 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((4+1)/3.0) * 1.5) + (COS((4+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (4 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 05
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-05',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(5/3.0) * 1.5) + (COS(5/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(5/3.0) * 1.5) + (COS(5/2.0) * 0.7) + 0.8 + (5 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(5/3.0) * 1.5) + (COS(5/2.0) * 0.7) - 0.9 - (5 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((5+1)/3.0) * 1.5) + (COS((5+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (5 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 06
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-06',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(6/3.0) * 1.5) + (COS(6/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(6/3.0) * 1.5) + (COS(6/2.0) * 0.7) + 0.8 + (6 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(6/3.0) * 1.5) + (COS(6/2.0) * 0.7) - 0.9 - (6 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((6+1)/3.0) * 1.5) + (COS((6+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (6 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 07
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-07',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(7/3.0) * 1.5) + (COS(7/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(7/3.0) * 1.5) + (COS(7/2.0) * 0.7) + 0.8 + (7 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(7/3.0) * 1.5) + (COS(7/2.0) * 0.7) - 0.9 - (7 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((7+1)/3.0) * 1.5) + (COS((7+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (7 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 08
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-08',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(8/3.0) * 1.5) + (COS(8/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(8/3.0) * 1.5) + (COS(8/2.0) * 0.7) + 0.8 + (8 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(8/3.0) * 1.5) + (COS(8/2.0) * 0.7) - 0.9 - (8 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((8+1)/3.0) * 1.5) + (COS((8+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (8 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 09
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-09',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(9/3.0) * 1.5) + (COS(9/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(9/3.0) * 1.5) + (COS(9/2.0) * 0.7) + 0.8 + (9 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(9/3.0) * 1.5) + (COS(9/2.0) * 0.7) - 0.9 - (9 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((9+1)/3.0) * 1.5) + (COS((9+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (9 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 10
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-10',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(10/3.0) * 1.5) + (COS(10/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(10/3.0) * 1.5) + (COS(10/2.0) * 0.7) + 0.8 + (10 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(10/3.0) * 1.5) + (COS(10/2.0) * 0.7) - 0.9 - (10 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((10+1)/3.0) * 1.5) + (COS((10+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (10 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 11
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-11',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(11/3.0) * 1.5) + (COS(11/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(11/3.0) * 1.5) + (COS(11/2.0) * 0.7) + 0.8 + (11 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(11/3.0) * 1.5) + (COS(11/2.0) * 0.7) - 0.9 - (11 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((11+1)/3.0) * 1.5) + (COS((11+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (11 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 12
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-12',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(12/3.0) * 1.5) + (COS(12/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(12/3.0) * 1.5) + (COS(12/2.0) * 0.7) + 0.8 + (12 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(12/3.0) * 1.5) + (COS(12/2.0) * 0.7) - 0.9 - (12 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((12+1)/3.0) * 1.5) + (COS((12+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (12 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 13
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-13',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(13/3.0) * 1.5) + (COS(13/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(13/3.0) * 1.5) + (COS(13/2.0) * 0.7) + 0.8 + (13 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(13/3.0) * 1.5) + (COS(13/2.0) * 0.7) - 0.9 - (13 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((13+1)/3.0) * 1.5) + (COS((13+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (13 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 14
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-14',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(14/3.0) * 1.5) + (COS(14/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(14/3.0) * 1.5) + (COS(14/2.0) * 0.7) + 0.8 + (14 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(14/3.0) * 1.5) + (COS(14/2.0) * 0.7) - 0.9 - (14 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((14+1)/3.0) * 1.5) + (COS((14+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (14 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 15
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-15',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(15/3.0) * 1.5) + (COS(15/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(15/3.0) * 1.5) + (COS(15/2.0) * 0.7) + 0.8 + (15 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(15/3.0) * 1.5) + (COS(15/2.0) * 0.7) - 0.9 - (15 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((15+1)/3.0) * 1.5) + (COS((15+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (15 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 16
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-16',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(16/3.0) * 1.5) + (COS(16/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(16/3.0) * 1.5) + (COS(16/2.0) * 0.7) + 0.8 + (16 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(16/3.0) * 1.5) + (COS(16/2.0) * 0.7) - 0.9 - (16 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((16+1)/3.0) * 1.5) + (COS((16+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (16 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 17
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-17',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(17/3.0) * 1.5) + (COS(17/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(17/3.0) * 1.5) + (COS(17/2.0) * 0.7) + 0.8 + (17 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(17/3.0) * 1.5) + (COS(17/2.0) * 0.7) - 0.9 - (17 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((17+1)/3.0) * 1.5) + (COS((17+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (17 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 18
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-18',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(18/3.0) * 1.5) + (COS(18/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(18/3.0) * 1.5) + (COS(18/2.0) * 0.7) + 0.8 + (18 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(18/3.0) * 1.5) + (COS(18/2.0) * 0.7) - 0.9 - (18 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((18+1)/3.0) * 1.5) + (COS((18+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (18 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 19
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-19',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(19/3.0) * 1.5) + (COS(19/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(19/3.0) * 1.5) + (COS(19/2.0) * 0.7) + 0.8 + (19 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(19/3.0) * 1.5) + (COS(19/2.0) * 0.7) - 0.9 - (19 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((19+1)/3.0) * 1.5) + (COS((19+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (19 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 20
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-20',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(20/3.0) * 1.5) + (COS(20/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(20/3.0) * 1.5) + (COS(20/2.0) * 0.7) + 0.8 + (20 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(20/3.0) * 1.5) + (COS(20/2.0) * 0.7) - 0.9 - (20 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((20+1)/3.0) * 1.5) + (COS((20+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (20 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 21
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-21',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(21/3.0) * 1.5) + (COS(21/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(21/3.0) * 1.5) + (COS(21/2.0) * 0.7) + 0.8 + (21 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(21/3.0) * 1.5) + (COS(21/2.0) * 0.7) - 0.9 - (21 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((21+1)/3.0) * 1.5) + (COS((21+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (21 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 22
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-22',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(22/3.0) * 1.5) + (COS(22/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(22/3.0) * 1.5) + (COS(22/2.0) * 0.7) + 0.8 + (22 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(22/3.0) * 1.5) + (COS(22/2.0) * 0.7) - 0.9 - (22 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((22+1)/3.0) * 1.5) + (COS((22+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (22 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 23
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-23',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(23/3.0) * 1.5) + (COS(23/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(23/3.0) * 1.5) + (COS(23/2.0) * 0.7) + 0.8 + (23 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(23/3.0) * 1.5) + (COS(23/2.0) * 0.7) - 0.9 - (23 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((23+1)/3.0) * 1.5) + (COS((23+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (23 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 24
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-24',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(24/3.0) * 1.5) + (COS(24/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(24/3.0) * 1.5) + (COS(24/2.0) * 0.7) + 0.8 + (24 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(24/3.0) * 1.5) + (COS(24/2.0) * 0.7) - 0.9 - (24 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((24+1)/3.0) * 1.5) + (COS((24+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (24 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 25
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-25',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(25/3.0) * 1.5) + (COS(25/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(25/3.0) * 1.5) + (COS(25/2.0) * 0.7) + 0.8 + (25 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(25/3.0) * 1.5) + (COS(25/2.0) * 0.7) - 0.9 - (25 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((25+1)/3.0) * 1.5) + (COS((25+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (25 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 26
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-26',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(26/3.0) * 1.5) + (COS(26/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(26/3.0) * 1.5) + (COS(26/2.0) * 0.7) + 0.8 + (26 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(26/3.0) * 1.5) + (COS(26/2.0) * 0.7) - 0.9 - (26 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((26+1)/3.0) * 1.5) + (COS((26+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (26 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 27
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-27',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(27/3.0) * 1.5) + (COS(27/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(27/3.0) * 1.5) + (COS(27/2.0) * 0.7) + 0.8 + (27 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(27/3.0) * 1.5) + (COS(27/2.0) * 0.7) - 0.9 - (27 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((27+1)/3.0) * 1.5) + (COS((27+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (27 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 28
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-28',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(28/3.0) * 1.5) + (COS(28/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(28/3.0) * 1.5) + (COS(28/2.0) * 0.7) + 0.8 + (28 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(28/3.0) * 1.5) + (COS(28/2.0) * 0.7) - 0.9 - (28 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((28+1)/3.0) * 1.5) + (COS((28+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (28 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 29
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-29',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(29/3.0) * 1.5) + (COS(29/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(29/3.0) * 1.5) + (COS(29/2.0) * 0.7) + 0.8 + (29 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(29/3.0) * 1.5) + (COS(29/2.0) * 0.7) - 0.9 - (29 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((29+1)/3.0) * 1.5) + (COS((29+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (29 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;

-- Dia 30
REPLACE INTO stock_quotes (CompanyId, QuoteDate, Open, High, Low, Close, Volume)
SELECT
  c.Id,
  '2025-09-30',
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(30/3.0) * 1.5) + (COS(30/2.0) * 0.7), 2) AS Open,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(30/3.0) * 1.5) + (COS(30/2.0) * 0.7) + 0.8 + (30 % 3) * 0.1, 2) AS High,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN(30/3.0) * 1.5) + (COS(30/2.0) * 0.7) - 0.9 - (30 % 2) * 0.1, 2) AS Low,
  ROUND((20 + (ABS(CRC32(c.Ticker)) % 60) * 1.0) + (SIN((30+1)/3.0) * 1.5) + (COS((30+1)/2.0) * 0.7), 2) AS Close,
  1000000 + (30 * 1000) + (ABS(CRC32(c.Ticker)) % 100000) AS Volume
FROM companies c;
